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
            bool multOf3 = IsMultipleOf(number, 3);
            bool multOf5 = IsMultipleOf(number, 5);
            bool multOf7 = IsMultipleOf(number, 7);
            
            if (multOf3)
            {
                if (multOf5)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else
                {
                    Console.WriteLine("Fizz");
                }
                
            }
            else
            {
                if (number % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(number);
                }
            }
        }

        private static bool IsMultipleOf(int number, int factor)
        {
            return number % factor == 0;
        }
    }
}