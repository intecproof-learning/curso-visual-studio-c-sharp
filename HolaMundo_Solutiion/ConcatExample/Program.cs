using System.Text;

namespace ConcatExample
{
    internal class Program
    {
        private static int[] dinamycArray = new int[1];
        private static int counter = 0;

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                AddElement(i);
            }

            Console.WriteLine(dinamycArray.Length);
        }

        private static void AddElement(int x)
        {
            if (dinamycArray.Length > counter)
            {
                dinamycArray[counter] = x;
                counter++;
            }
            else
            {
                int[] tmp = new int[dinamycArray.Length];
                for (int i = 0; i < tmp.Length; i++)
                {
                    tmp[i] = dinamycArray[i];
                }
                dinamycArray = new int[counter + 10];

                for (int i = 0; i < tmp.Length; i++)
                {
                    dinamycArray[i] = tmp[i];
                }

                dinamycArray[counter] = x;
                counter++;
            }

        }
    }
}