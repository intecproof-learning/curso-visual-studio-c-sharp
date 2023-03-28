using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Finanzas.CursoVisualStudio.Shared.DTOs
{
    /// <summary>
    /// Clase que representa a  un Usuario
    /// </summary>
    public class User : IComparable<User>
    {
        #region Properties
        /// <summary>
        /// ID de tipo entero que debe ser único
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "El ID del usuario es requerido")]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Correo Electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El Correo Electrónico no tiene el formato esperado")]
        [DisplayName("Correo electrónico")]
        public String Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Apodo es requerido")]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "El Apodo debe tener entre 8 y 12 caracteres")]
        [RegularExpression("^[A-Za-z0-9]{8,12}$", ErrorMessage = "El Apodo solo puede tener letras y/o números")]
        [DisplayName("Apodo")]
        public String NickName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La Contraseña es requerida")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre 8 y 16 caracteres")]
        [DisplayName("Contraseña")]
        public String Password { get; set; }

        public List<UserModuleRelDto> RelatedModules { get; set; }
        #endregion

        public User()
        {
            this.RelatedModules = null;
        }

        #region Methods
        //CompareTo regresa 0 si ambos ojetos son iguales
        //1 = si el objeto de la izquierda es mayor
        //-1 = si el objeto de la izquierda es menor
        public int CompareTo(User? other)
        {
            if (other == null)
                return -1;

            return this.ID.CompareTo(other.ID);
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj.GetType() == typeof(User))
            {
                User tmp = (User)obj;
                return this.ID.Equals(tmp.ID);
            }

            return false;
        }

        public override string ToString()
        {
            return $"Apodo: {this.NickName} - Correo electrónico: {this.Email}";
        }
        #endregion
    }
}