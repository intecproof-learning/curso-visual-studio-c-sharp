using System.ComponentModel.DataAnnotations;

namespace Finanzas.CursoVisualStudio.Shared.DTOs
{
    public class ObjectResponse<TObject>
    {
        public TObject ObjectResult { get; set; }
        public String Message { get; set; }
        public ICollection<ValidationResult> Errors { get; set; }
        public bool IsSucess { get; set; }
    }
}