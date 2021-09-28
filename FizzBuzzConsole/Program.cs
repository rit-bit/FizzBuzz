using System;

namespace FizzBuzzConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                Print(i);
            }
        }

        private static void Print(int number)
        {
            if (number % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else
            {
                Console.WriteLine(number);
            }
        }
    }
}