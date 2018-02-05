using System;

namespace GUILabHelloWorld
{
    internal class addnumber
    {
        private static void Main()
        {
            int x, y;
            Console.WriteLine("Enter 1st number: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out x)) break;
                Console.WriteLine("Enter a number only");
            }

            Console.WriteLine("Enter 2nd number: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out y)) break;
                Console.WriteLine("Enter a number only");
            }

            Console.WriteLine("Result is: " + (x + y));
        }
    }
}
