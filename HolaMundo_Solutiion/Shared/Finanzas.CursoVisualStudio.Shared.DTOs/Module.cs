namespace Finanzas.CursoVisualStudio.Shared.DTOs
{
    public class Module : IComparable<Module>
    {
        public int ID { get; set; }
        public String Name { get; set; }
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
