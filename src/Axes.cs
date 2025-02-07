using System;
using System.Text;

namespace Axes
{
    class Axes
    {
        public static void Main(String[] args) //Program Entry point
        {
            Console.WriteLine("Welcome to the Axes Interpreter: ");
            HandleParameters(args);
        }

        private static void HandleParameters(String[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine("Parameter: " + arg);
            }
        }
    }
}
