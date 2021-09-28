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

            var output = GetFizzBuzzText(number, multOf3, multOf5, multOf7, multOf11);
            output = checkForFezz(output, number);
            Console.WriteLine(output);
        }

        private static string GetFizzBuzzText(int num, bool fizz, bool buzz, bool bang, bool bong)
        {
            if (bong)
            {
                return "Bong";
            }
            var text = "";
            if (fizz)
            {
                text += "Fizz";
            }

            if (buzz)
            {
                text += "Buzz";
            }

            if (bang)
            {
                text += "Bang";
            }

            return text == "" ? "" + num : text;
        }

        private static string checkForFezz(string output, int number)
        {
            if (IsMultipleOf(number, 13))
            {
                if (output.Equals("" + number))
                {
                    return "Fezz";
                }
                else
                {
                    return InsertFezz(output);
                }
            }

            return output;
        }

        private static string InsertFezz(string output)
        {
            var index = output.IndexOf("B", StringComparison.Ordinal);
            if (index == -1)
            {
                return output + "Fezz";
            }
            else
            {
                return output.Insert(index, "Fezz");
            }
        }

        private static bool IsMultipleOf(int number, int factor)
        {
            return number % factor == 0;
        }
    }
}