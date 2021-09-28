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
            var multOf3 = IsMultipleOf(number, 3);
            var multOf5 = IsMultipleOf(number, 5);
            var multOf7 = IsMultipleOf(number, 7);
            
            Console.WriteLine(GetFizzBuzzText(number, multOf3, multOf5, multOf7));
        }

        private static string GetFizzBuzzText(int num, bool fizz, bool buzz, bool bang)
        {
            var text = "";
            if (fizz)
            {
                text += "fizz";
            }

            if (buzz)
            {
                text += "buzz";
            }

            if (bang)
            {
                text += "bang";
            }

            return text == "" ? "" + num : text;
        }

        private static bool IsMultipleOf(int number, int factor)
        {
            return number % factor == 0;
        }
    }
}