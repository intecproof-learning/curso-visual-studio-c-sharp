using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Finanzas.CursoVisualStudio.Shared.Utilities
{
    public class Utilities
    {

        public static String session = String.Empty;

        public static bool IsValidModel<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();
            try
            {
                return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
            }
            catch
            {
                throw;
            }
        }

        public static bool LogMovement
            (ModulesEnum moduleLog
            , LogProperties properties)
        {
            String logPath = String.Empty;
            switch (moduleLog)
            {
                case ModulesEnum.Users:
                    logPath = "C:\\Temp\\Log\\UsersLog.csv";
                    break;
                case ModulesEnum.Modules:
                    logPath = "C:\\Temp\\Log\\ModulesLog.csv";
                    break;
            }

            if (Directory.Exists(Path.GetDirectoryName
                (logPath)) == false)
            {
                Directory.CreateDirectory(Path
                    .GetDirectoryName(logPath));
            }

            if (File.Exists(logPath) == false)
            {
                FileStream fs = File.Create(logPath);
                fs.Close();
                fs.Dispose();
            }

            using (StreamWriter sw
                = File.AppendText(logPath))
            {
                sw.WriteLineAsync(
                    $"{moduleLog},{properties.Action}," +
                    $"{properties.Message}, {properties.MessageType}," +
                    $"{properties.ObjectID}, {properties.ExecutionDate}," +
                    $"{Utilities.session}");
            }

            return true;
        }
    }

    public static class EnumExtensionMethods
    {
        public static String GetDescription
            (this Enum enumValue)
        {
            return enumValue.GetType().GetMember(
                enumValue.ToString()).First()
                .GetCustomAttribute<DescriptionAttribute>()?
                .Description ?? "Enumerador sin descripción";
        }
    }


    public enum ModulesEnum
    {
        [Description("Módulo de usuarios")]
        Users,
        [Description("Ventana de módulos")]
        Modules
    }

    public enum UserAcctionsEnum
    {
        Query,
        Insert,
        Update,
        Delete
    }

    public enum LogMessageType
    {
        Info,
        Waring,
        Error
    }

    public class LogProperties
    {
        public UserAcctionsEnum Action { get; set; }

        public LogMessageType MessageType { get; set; }

        public string Message { get; set; }

        public DateTime ExecutionDate { get; set; }

        public String ObjectID { get; set; }
    }
}