using System.ComponentModel.DataAnnotations;

namespace Finanzas.CursoVisualStudio.Shared.DTOs
{
    public class Module : IComparable<Module>
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El ID del módulo es requerido")]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre del módulo es requerido")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El Nombre del módulo debe tener entre 3 y 20 carácteres")]
        [RegularExpression("^[A-Za-z0-9]{3,20}$", ErrorMessage = "El Nombre solo puede tener letras y/o números")]
        public String Name { get; set; }
        
        [StringLength(150, ErrorMessage = "La Descripción del módulo debe tener máximo 150 carácteres")]
        public String Description { get; set; }

        public int CompareTo(Module? other)
        {
            if (other == null)
                return -1;

            return this.ID.CompareTo(other.ID);
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj.GetType() == typeof(Module))
            {
                Module tmp = (Module)obj;
                return this.ID.Equals(tmp.ID);
            }

            return false;
        }

        public override string ToString()
        {
            return $"ID: {this.Description} - Nombre: {this.Name}";
        }
    }
}
