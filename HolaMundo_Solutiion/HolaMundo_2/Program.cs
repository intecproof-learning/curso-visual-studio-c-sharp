namespace HolaMundo_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hola mundo de finanzas");
            string input = Console.ReadLine();
            Console.WriteLine("Usted escribió: " + input);
            Console.WriteLine(short.MinValue + " - " + short.MaxValue);
            */

            Operations op = new Operations();

            string numS1 = Console.ReadLine();
            string numS2 = Console.ReadLine();

            //int num1 = int.Parse(numS1);
            //int num2 = int.Parse(numS2);


            int num1Parse = 0;
            int num2Parse = 0;

            if (int.TryParse(numS1, out num1Parse) == true
                && int.TryParse(numS2, out num2Parse) == false)
            {
                int resultado = op.Suma(num1Parse, num2Parse);
                Console.WriteLine(resultado);
            }
            else
            {
                Console.WriteLine("No se cumplió la sentencia del IF");
            }

            Console.WriteLine("AND");
            //AND
            Console.WriteLine(true && true);
            Console.WriteLine(true && false);
            Console.WriteLine(false && true);
            Console.WriteLine(false && false);

            Console.WriteLine("OR");
            //OR
            Console.WriteLine(true || true);
            Console.WriteLine(true || false);
            Console.WriteLine(false || true);
            Console.WriteLine(false || false);

            //Suma +
            //Resta -
            //Div /
            //Mult *

        }
    }

    public class Operations
    {
        public int Suma(int x, int y)
        {
            return this.Suma_P(x, y);
        }

        private int Suma_P(int x, int y)
        {
            return x + y;
        }
    }
}