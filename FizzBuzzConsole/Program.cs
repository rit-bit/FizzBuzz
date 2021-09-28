using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;

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
            output = CheckForFezz(output, number);
            Console.WriteLine(string.Join("", output));
        }

        private static List<string> GetFizzBuzzText(int num, bool fizz, bool buzz, bool bang, bool bong)
        {
            if (bong)
            {
                return new List<string> {"Bong"};
            }
            var text = new List<string>();
            if (fizz)
            {
                text.Add("Fizz");
            }

            if (buzz)
            {
                text.Add("Buzz");
            }

            if (bang)
            {
                text.Add("Bang");
            }

            if (IsMultipleOf(num, 17))
            {
                text = ReverseFizzesBuzzesBangs(text);
            }

            return text.Count == 0 ? new List<string>{"" + num} : text;
        }

        private static List<string> ReverseFizzesBuzzesBangs(List<string> output)
        {
            return output; // TODO Write this
        }

        private static List<string> CheckForFezz(List<string> output, int number)
        {
            if (IsMultipleOf(number, 13))
            {
                if (output.Count == 1 && output[0].Equals("" + number))
                {
                    return new List<string>{"Fezz"};
                }
                else
                {
                    return InsertFezz(output);
                }
            }

            return output;
        }

        private static List<string> InsertFezz(List<string> output)
        {
            var index = -1;
            for (var i = 0; i < output.Count; i++)
            {
                var word = output[0];
                if (word[0] == 'B')
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                output.Add("Fezz");
                return output;
            }
            else
            {
                output.Insert(index, "Fezz");
                return output;
            }
        }

        private static bool IsMultipleOf(int number, int factor)
        {
            return number % factor == 0;
        }
    }
}