using System.ComponentModel.DataAnnotations;

namespace Finanzas.CursoVisualStudio.Shared.Utilities
{
    public class Utilities
    {
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
            (ModulesEnum moduleLog)
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
        }
    }

    public enum ModulesEnum
    {
        Users,
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