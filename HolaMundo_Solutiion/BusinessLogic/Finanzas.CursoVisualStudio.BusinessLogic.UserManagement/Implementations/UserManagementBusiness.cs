using Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Interfaces;
using Finanzas.CursoVisualStudio.DataAccess.Repositories.Implementations;
using Finanzas.CursoVisualStudio.Shared.DTOs;

namespace Finanzas.CursoVisualStudio.BusinessLogic.UserManagement.Implementations
{
    public class UserManagementBusiness : IUserManagementBusiness
    {
        private readonly byte nickNameMinLen;
        private readonly byte nickNameMaxLen;
        private Dictionary<string, string> errorList;
        private UnitOfWork uRepo;

        public UserManagementBusiness()
        {
            this.nickNameMaxLen = 12;
            this.nickNameMinLen = 8;
            this.errorList = new Dictionary<string, string>();
            this.uRepo = new UnitOfWork();
        }

        public Dictionary<string, string> CreateOrUpdateUser(User item)
        {
            this.ValidateUser(item);
            return this.errorList;
        }

        private void ValidateUser(User item)
        {
            if (item.NickName.Length < this.nickNameMinLen
                || item.NickName.Length > this.nickNameMaxLen)
            {
                this.errorList.Add("Longitud del apodo", "El apodo debe tener entre 8 y 12 carácteres");
            }

            var matches = item.NickName.Intersect("@°¬|#$%&/");
            if (matches.Count() > 0)
            {
                this.errorList.Add("Carácteres del apodo", $"El apodo no debe tener los siguientes carácteres:\"@°¬|#$%&/\". Se encontraron los siguientes carácteres: {new string(matches.ToArray())}");
            }
        }
    }
}