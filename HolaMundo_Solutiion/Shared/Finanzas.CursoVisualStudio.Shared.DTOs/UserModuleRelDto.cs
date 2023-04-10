using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzas.CursoVisualStudio.Shared.DTOs
{
    public class UserModuleRelDto : Module
    {
        [DisplayName("Activo")]
        public bool IsActive { get; set; }
    }
}
