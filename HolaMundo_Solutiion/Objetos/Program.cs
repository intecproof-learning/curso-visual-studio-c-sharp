namespace Objetos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*SerVivo sv = new SerVivo();
            sv.Nombre = "Planta de jardín";
            Console.WriteLine(sv.ToString());

            SerVivo sv2 = new SerVivo(TiposSerVivo.Humanos);
            sv2.Nombre = "Juan Pérez Penas";
            Console.WriteLine(sv2.ToString());

            sv2 = new SerVivo(TiposSerVivo.Humanos, "Juan Pérez Penas");
            Console.WriteLine(sv2.ToString());

            TiposSerVivo nuevoTipo;
            sv2.ConvertirTipo(0, out nuevoTipo);
            sv2.Tipo = nuevoTipo;
            Console.WriteLine(sv2.ToString());

            (int, string) tupla1 = (2, "2");
            Console.WriteLine(tupla1);
            tupla1.Item1 = 3;
            tupla1.Item2 = "3";
            Console.WriteLine(tupla1);

            (int a, string b) tupla2 = (2, "2");
            Console.WriteLine(tupla2);
            Console.WriteLine(tupla2.a);
            Console.WriteLine(tupla2.b);

            (int a, int b, int c, int d) tupla3 = (1, 2, 3, 4);
            Console.WriteLine(tupla3);

            Console.WriteLine("Hello, World!");*/

            //Ejemplo tipos por valor y referencia
            /*SerVivo sv = new SerVivo(TiposSerVivo.Plantas,
                "Rosa");
            int x = 10;

            Console.WriteLine(sv.ToString());
            Console.WriteLine($"El valor de x es: {x}");

            TipoValor(x, sv);

            Console.WriteLine(sv.ToString());
            Console.WriteLine($"El valor de x es: {x}");*/

            Humano h1 = new Humano()
            {
                FechaNacimiento = DateTime.Now,
                LugarNacimiento = "Finanzas Puebla",
                Nombre = "Pedro Pérez Penas",
                Sexo = "Masculino"
            };

            Gato g1 = new Gato()
            {
                FechaNacimiento = DateTime.Now,
                LugarNacimiento = "Finanzas Puebla",
                Habitat = "Hogar",
                Nombre = "Michi",
                NumeroPatas = 4,
                Raza = "Callejero"
            };

            h1.Comer();
            h1.Moverse();
            h1.Morir();
            h1.Vivir();

            g1.Comer();
            g1.Moverse();
            g1.Morir();
            g1.Vivir();

            List<Servivo_2> seresVivos = new List<Servivo_2>();
            seresVivos.Add(h1);
            seresVivos.Add(g1);
            //seresVivos.Remove(h1);

            Console.WriteLine("\n\n\nForeach");

            foreach (var item in seresVivos)
            {
                item.Comer();
                item.Moverse();
                item.Morir();
                item.Vivir();
            }

            Console.WriteLine();
            Console.WriteLine("Gato como Ser Vivo");
            Servivo_2 svGato = g1;
            //svGato a pesar de que contienen un Gato
            //Solo tiene acceso a las propiedades y 
            //funciones de la clase Servivo_2

            Console.WriteLine(g1.Raza);//Solo copiar hasta acá
            
            //Console.WriteLine(svGato.Raza);
            //Raza es una propiedad de Gato
            //Console.WriteLine(svGato.Habitat);
            //Habitat es una propiedad de Animal
            //Console.WriteLine(svGato.NumeroPatas);
            //NumeroPatas es una propidad de Animal

            Console.WriteLine(svGato.FechaNacimiento);
            Console.WriteLine(svGato.LugarNacimiento);
        }

        public static void TipoValor(int x, SerVivo planta)
        {
            x = x = + 1;
            planta.Nombre = "Nombre modificado desde el método";
        }
    }

    public sealed class Humano : Servivo_2
    {
        public String Sexo { get; set; }

        public override void Comer()
        {
            Console.WriteLine("Estoy comiendo con mis manitas");
        }

        public override void Moverse()
        {
            Console.WriteLine("Estoy caminando con mis dos pies");
        }

        public override void Morir()
        {
            Console.WriteLine("Generalmente vivo 70 años");
        }
    }

    public abstract class Animal : Servivo_2
    {
        public int NumeroPatas { get; set; }
        public String Habitat { get; set; }

        public sealed override void Morir()
        {
            Console.WriteLine("Generalmente vivo 20 años");
        }
    }

    public sealed class Gato : Animal
    {
        public String Raza { get; set; }

        public override void Comer()
        {
            Console.WriteLine("Estoy comienod ratones");
        }

        public override void Moverse()
        {
            Console.WriteLine("Estoy caminando en 4 patas");
        }
    }

    public abstract class Servivo_2
    {
        public String Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String LugarNacimiento { get; set; }


        public abstract void Moverse();

        public abstract void Comer();

        public void Vivir()
        {
            Console.WriteLine("Justo ahora estoy vivo");
        }

        public virtual void Morir()
        {
            Console.WriteLine("Generalmente vivo 2 semanas");
        }
    }

    public class SerVivo
    {
        private TiposSerVivo tipo;
        private String nombre;

        public TiposSerVivo Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        public string Nombre { get =>  nombre; set => nombre = value; }

        public SerVivo()
        {
        }

        public SerVivo(TiposSerVivo tipo)
        {
            this.tipo = tipo;
        }

        public SerVivo(String nombre)
        {
            this.nombre = nombre;
        }

        public SerVivo(TiposSerVivo tipo, String nombre)
        {
            this.tipo = tipo;
            this.nombre = nombre;
        }

        public bool ConvertirTipo(int tipo, out TiposSerVivo nuevoTipo)
        {
            nuevoTipo = TiposSerVivo.Humanos;

            try
            {
                nuevoTipo = (TiposSerVivo)tipo;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TiposSerVivo ConvertirTipo(int tipo)
        {

            try
            {
                return (TiposSerVivo)tipo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override string ToString()
        {
            return $"Soy un {this.tipo} y me llamo {this.nombre}";
        }
    }

    public enum TiposSerVivo
    {
        Plantas,
        Humanos,
        Animales,
        MicroOrganismos
    }
}