namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al programa ejemplo de calculadora");
            Console.WriteLine("Por favor ingresa el número de la opción a ejecutar");
            Console.WriteLine("1.- Suma\n2.- Resta\n3.- Multiplicación\n4.- División");

            string optionS = Console.ReadLine();
            int selectedOption = 0;

            if (int.TryParse(optionS, out selectedOption) == true
                && (selectedOption > 0 && selectedOption < 5))
            {
                Console.WriteLine("Por favor captura 1 número entero");
                string num1S = Console.ReadLine();

                Console.WriteLine("Por favor captura 1 número entero");
                string num2S = Console.ReadLine();

                int num1 = 0;
                int num2 = 0;

                if (int.TryParse(num1S, out num1) == true &&
                    int.TryParse(num2S, out num2) == true)
                {

                    Operation op = new Operation();

                    if (selectedOption == 1)
                    {
                        Console.WriteLine($"La suma de {num1} + {num2} = {op.Addition(num1, num2)}");
                        string message = String.Format("La suma de {0} + {1} = {2}",
                            num1, num2, op.Addition(num1, num2));
                        Console.WriteLine(message);
                    }

                    if (selectedOption == 2)
                    {
                        Console.WriteLine($"La resta de {num1} - {num2} = {op.Substract(num1, num2)}");
                    }

                    if (selectedOption == 3)
                    {
                        Console.WriteLine($"La multiplicación de {num1} * {num2} = {op.Multiplication(num1, num2)}");
                    }

                    if (selectedOption == 4)
                    {
                        Console.WriteLine($"La división de {num1} / {num2} = {op.Division(num1, num2)}");
                    }
                }
                else
                {
                    Console.WriteLine("Debes ingresar números enteros por favor");
                }
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor vuelva a ejecutar el programa");
            }

        }
    }

    public class Operation
    {
        public int Addition(int x, int y)
        {
            return x + y;
        }

        public int Substract(int x, int y)
        {
            return x - y;
        }

        public int Multiplication(int x, int y)
        {
            return x * y;
        }

        public float Division(int x, int y)
        {
            return x / (float)y;
        }
    }
}