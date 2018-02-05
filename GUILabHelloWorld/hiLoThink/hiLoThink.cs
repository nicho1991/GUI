using System;

namespace HiLoThink
{
    internal class HiLoThink
    {
        private static void Main()
        {
            Console.WriteLine("Welcome to Hi-Lo game!");
            Console.WriteLine("Think of a number between 1 and 100");
            Console.WriteLine("I will make as guess");
            var random = new Random();
            var low = 1;
            var high = 101;
            var number = random.Next(low, high);

            while (true)
            {
                Console.WriteLine("My quess is: " + number);
                Console.WriteLine("Tell me if i'm (H)igh, (L)ow or (E)qual? ");

                var hiLo = Console.ReadLine();

                if (hiLo == "H")
                {
                    Console.WriteLine("Okay too high.. Making new guess.");
                    high = number;
                    number = random.Next(low, high);
                }
                else if (hiLo == "L")
                {
                    Console.WriteLine("Okay too low.. Making new guess.");
                    low = number;
                    number = random.Next(low, high);
                }
                else if (hiLo == "E")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("press H,L or E");
                }
            }

            Console.WriteLine("yay");
        }
    }
}