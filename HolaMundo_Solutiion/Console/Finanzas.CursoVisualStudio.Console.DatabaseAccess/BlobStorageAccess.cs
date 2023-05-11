using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;

namespace Cemex.Arkik.DataAccess.AzureStorage.BlobStorage
{
    /// <summary>
    /// Blob storage class to upload, download and delete blobs in table storage based con connection string stored in app settings
    /// </summary>
    public class BlobStorageAccess
    {
        private String connectionString = "";

        private BlobServiceClient blobServiceClient;

        /// <summary>
        /// Empty contructor to initialize variables and create the blob client based on connections string 
        /// </summary>
        public BlobStorageAccess()
        {
            blobServiceClient = new BlobServiceClient(connectionString);
        }

        /// <summary>
        /// Chek if there is a file in the specified container
        /// </summary>
        /// <param name="containerName">Container name</param>
        /// <param name="fileName">File name</param>
        /// <returns>Boolean value that indicates whether if there is a file in the container or not</returns>
        public async Task<bool> FileExists(string containerName, string fileName)
        {
            try
            {
                BlobContainerClient blobContainerClient = await this.CreteContainerIfNotExists(containerName);
                BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);
                return await blobClient.ExistsAsync();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Upload a file in the specified container
        /// </summary>
        /// <param name="containerName">Container name</param>
        /// <param name="fileName">File name. It coulb be only the file name or a path with the file name like TenantID\ModuleName\FileName</param>
        /// <param name="content">File content (Text only, like json, xml, plain text, etc.)</param>
        /// <param name="generateSAS">Is it required to generate a Shared access Signature?</param>
        /// <param name="isPublicContainer">Is it required a public container</param>
        /// <returns>Blob File URI</returns>
        public async Task<string> UploadBlob(string containerName, string fileName, string content, bool generateSAS = false, bool isPublicContainer = false)
        {
            try
            {
                string sasToken = string.Empty;

                BlobContainerClient blobContainerClient = await this.CreteContainerIfNotExists(containerName, isPublicContainer);
                BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);

                await blobClient.UploadAsync(BinaryData.FromString(content), overwrite: true);

                if (generateSAS)
                {
                    var values = connectionString.Split(";");

                    var valueAccount = values[1].Substring("AccountName=".Length);
                    var valueKey = values[2].Substring("AccountKey=".Length);

                    BlobSasBuilder blobSasBuilder = new BlobSasBuilder()
                    {
                        BlobContainerName = blobClient.BlobContainerName,
                        BlobName = blobClient.Name,
                        Resource = "b",
                        StartsOn = new DateTimeOffset(DateTime.Now),
                        ExpiresOn = new DateTimeOffset(DateTime.Now.AddYears(1)),
                    };
                    blobSasBuilder.SetPermissions(BlobSasPermissions.Read);

                    StorageSharedKeyCredential storageSharedKeyCredential = new StorageSharedKeyCredential(valueAccount, valueKey);

                    sasToken = blobSasBuilder.ToSasQueryParameters(storageSharedKeyCredential).ToString();
                }

                if (generateSAS == true)
                    return $"{blobClient.Uri.AbsoluteUri}?{sasToken}";

                return blobClient.Uri.AbsoluteUri;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Upload a file in the specified container
        /// </summary>
        /// <param name="containerName">Container name</param>
        /// <param name="fileName">File name</param>
        /// <param name="content">File content (Stream)</param>
        /// <param name="generateSAS">Is it required to generate a Shared access Signature?</param>
        /// <param name="isPublicContainer">Is it required a public container</param>
        /// <returns>Blob File URI</returns>
        public async Task<string> UploadBlob(string containerName, string fileName, Stream content, bool generateSAS = false, bool isPublicContainer = false)
        {
            try
            {
                string sasToken = string.Empty;

                BlobContainerClient blobContainerClient = await this.CreteContainerIfNotExists(containerName, isPublicContainer);
                BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);

                await blobClient.UploadAsync(content, overwrite: true);

                if (generateSAS)
                {
                    var values = connectionString.Split(";");

                    var valueAccount = values[1].Substring("AccountName=".Length);
                    var valueKey = values[2].Substring("AccountKey=".Length);

                    BlobSasBuilder blobSasBuilder = new BlobSasBuilder()
                    {
                        BlobContainerName = blobClient.BlobContainerName,
                        BlobName = blobClient.Name,
                        Resource = "b",
                        StartsOn = new DateTimeOffset(DateTime.Now),
                        ExpiresOn = new DateTimeOffset(DateTime.Now.AddYears(1))
                    };
                    blobSasBuilder.SetPermissions(BlobSasPermissions.Read);

                    StorageSharedKeyCredential storageSharedKeyCredential = new StorageSharedKeyCredential(valueAccount, valueKey);

                    sasToken = blobSasBuilder.ToSasQueryParameters(storageSharedKeyCredential).ToString();
                }

                if (generateSAS == true)
                    return $"{blobClient.Uri.AbsoluteUri}?{sasToken}";

                return blobClient.Uri.AbsoluteUri;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get the text content from blob stored in a container
        /// </summary>
        /// <param name="containerName">Container name</param>
        /// <param name="fileName">File name</param>
        /// <returns>String with the text content from the blob</returns>
        public async Task<string> GetBlobContent(string containerName, string fileName)
        {
            try
            {
                BlobContainerClient blobContainerClient = await CreteContainerIfNotExists(containerName);
                BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);
                BlobDownloadResult downloadResult = await blobClient.DownloadContentAsync();
                return downloadResult.Content.ToString();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get the stream content from blob stored in a container
        /// </summary>
        /// <param name="containerName">Container name</param>
        /// <param name="fileName">File name</param>
        /// <returns>String with the text content from the blob</returns>
        public async Task<Stream> GetBlobContentStream(string containerName, string fileName)
        {
            try
            {
                BlobContainerClient blobContainerClient = await CreteContainerIfNotExists(containerName);
                BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);
                BlobDownloadStreamingResult downloadResult = await blobClient.DownloadStreamingAsync();
                return downloadResult.Content;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get the text content from URI blob
        /// </summary>
        /// <param name="blobUri">Blob URI</param>
        /// <returns>String with the text content from the blob</returns>
        public async Task<string> GetBlobContent(Uri blobUri)
        {
            try
            {
                BlobUriBuilder uriBuilder = new BlobUriBuilder(blobUri);

                return await this.GetBlobContent(uriBuilder.BlobContainerName, uriBuilder.BlobName);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete blob file from the specified container
        /// </summary>
        /// <param name="containerName">Container name</param>
        /// <param name="fileName">File name</param>
        /// <param name="isPublicContainer">Is it required a public container</param>
        /// <returns></returns>
        public async Task DeleteBlob(string containerName, string fileName)
        {
            try
            {
                BlobContainerClient blobContainerClient = await this.CreteContainerIfNotExists(containerName);
                BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);
                await blobClient.DeleteAsync();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// It create a container if it does not exists
        /// </summary>
        /// <param name="containerName">Container name</param>
        /// <param name="isPublicContainer">Is it required a public container</param>
        /// <returns>The created CloudBlobContainer</returns>
        private async Task<BlobContainerClient> CreteContainerIfNotExists(string containerName, bool isPublicContainer = false)
        {
            try
            {
                BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName.ToLower());
                await blobContainerClient.CreateIfNotExistsAsync();

                await blobContainerClient.SetAccessPolicyAsync(isPublicContainer == true ? PublicAccessType.BlobContainer : PublicAccessType.None);

                return blobContainerClient;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get a List of blobs in a container
        /// </summary>
        /// <param name="containerName">Container name</param>
        /// <param name="prefix">Specifies a string that filters the results to return only blobs
        /// whose name begins with the specified prefix. Empty for all blobs in the container.</param>
        /// <param name="blobTraits">Optional. Specifies trait options for shaping the blobs</param>
        /// <param name="blobStates">Optional. Specifies state options for filtering the blobs</param>
        /// <param name="cancellationToken">Optional. Tokento propagate
        /// notifications that the operation should be cancelled.</param>
        /// <returns>A list of BlobItem in the container</returns>
        public List<BlobItem> GetBlobList(string containerName, string prefix, BlobTraits blobTraits = BlobTraits.None,
            BlobStates blobStates = BlobStates.None, CancellationToken cancellationToken = default)
        {
            try
            {
                BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
                List<BlobItem> blobList = blobContainerClient.GetBlobs(blobTraits, blobStates, prefix, cancellationToken).ToList();
                blobContainerClient.GetBlobs();
                return blobList;
            }
            catch
            {
                throw;
            }
        }
    }
}