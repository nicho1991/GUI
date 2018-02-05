using System;

namespace hilo
{
    internal class hilo
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hi-Lo game!");
            Console.WriteLine("computer makes a random number between 1 - 100, guess it");
            var random = new Random();
            var number = random.Next(1, 101);
            int x;

            Console.WriteLine("Enter your quess: ");
            while (true)
                if (int.TryParse(Console.ReadLine(), out x))
                {
                    if (x < number) Console.WriteLine("Too low, try again.");

                    if (x > number) Console.WriteLine("too high, try again.");

                    if (x == number)
                        break;
                }
                else
                {
                    Console.WriteLine("Enter a number only");
                }

            Console.WriteLine("You guessed the number!");
        }
    }
}