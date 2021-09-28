using System;

namespace FizzBuzzConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var howManyTimes = HowManyNumbersToPrint();
            
            for (int i = 1; i <= howManyTimes; i++)
            {
                Print(i);
            }
        }

        private static int HowManyNumbersToPrint()
        {
            while (true) {
                Console.WriteLine("How many numbers do you want to print?");
                var input = Console.ReadLine();
                try
                {
                    return Convert.ToInt32(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please type a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number was too large. Please try a smaller number.");
                }
            }
        }

        private static void Print(int number)
        {
            var multOf3 = IsMultipleOf(number, 3);
            var multOf5 = IsMultipleOf(number, 5);
            var multOf7 = IsMultipleOf(number, 7);
            var multOf11 = IsMultipleOf(number, 11);

            Console.WriteLine(GetFizzBuzzText(number, multOf3, multOf5, multOf7, multOf11));
        }

        private static string GetFizzBuzzText(int num, bool fizz, bool buzz, bool bang, bool bong)
        {
            if (bong)
            {
                return "bong";
            }
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