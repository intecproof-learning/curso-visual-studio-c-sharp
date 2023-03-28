using System.ComponentModel;

namespace Finanzas.CursoVisualStudio.Shared.DTOs
{
    public class ModuleUserRelDto : User
    {
        [DisplayName("Activo")]
        public bool IsActive { get; set; }
    }
}
