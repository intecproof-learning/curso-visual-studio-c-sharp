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
        public int ID { get; set; }
        public String Email { get; set; }
        public String NickName { get; set; }
        public String Password { get; set; }
        #endregion

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