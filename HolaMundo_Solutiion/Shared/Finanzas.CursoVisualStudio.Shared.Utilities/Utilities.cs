using System.ComponentModel.DataAnnotations;

namespace Finanzas.CursoVisualStudio.Shared.Utilities
{
    public class Utilities
    {
        public static bool IsValidModel<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}