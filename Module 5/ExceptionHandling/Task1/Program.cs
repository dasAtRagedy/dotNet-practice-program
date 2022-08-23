using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();
                try
                {
                    if (string.IsNullOrEmpty(input))
                        throw new ArgumentNullException(input, "Input is empty!");
                    Console.WriteLine(input[0]);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}