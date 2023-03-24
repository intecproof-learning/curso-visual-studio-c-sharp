using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Finanzas.CursoVisualStudio.Shared.DTOs
{
    public class Module : IComparable<Module>, INotifyPropertyChanged
    {
        private int id;
        private String name;
        private String description;

        [Required(AllowEmptyStrings = false, ErrorMessage = "El ID del módulo es requerido")]
        public int ID
        {
            get => id;
            set
            {
                this.id = value;
                this.NotifyPropertyChanged();
            }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Nombre del módulo es requerido")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El Nombre del módulo debe tener entre 3 y 20 carácteres")]
        [RegularExpression(@"^[\w\s]{3,20}$", ErrorMessage = "El Nombre solo puede tener letras y/o números")]
        public String Name
        {
            get => this.name;
            set
            {
                this.name = value;
                this.NotifyPropertyChanged();
            }
        }

        [StringLength(150, ErrorMessage = "La Descripción del módulo debe tener máximo 150 carácteres")]
        public String Description
        {
            get => this.description;
            set
            {
                this.description = value;
                this.NotifyPropertyChanged();
            }
        }

        public List<ModuleUserRelDto> RelatedUsers { get; set; }

        public Module()
        {
            this.RelatedUsers = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

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

        private void NotifyPropertyChanged
            ([CallerMemberName]
        String propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this,
                    new PropertyChangedEventArgs
                    (propertyName));
            }
        }
    }
}
