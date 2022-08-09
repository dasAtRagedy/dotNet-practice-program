using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            try
            {
                if (string.IsNullOrEmpty(input))
                    throw new ArgumentNullException(input, "Input is empty!");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}