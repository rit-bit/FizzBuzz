using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;

namespace FizzBuzzConsole
{
    public class FizzBuzzProgram : IEnumerable
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";
        private const string Bang = "Bang";
        private const string Bong = "Bong";
        private const string Fezz = "Fezz";
        private const string Rev = "Rev";

        private readonly int _limit;
        private readonly Dictionary<string, bool> _options;

        private FizzBuzzProgram(int limit, Dictionary<string, bool> options)
        {
            this._limit = limit;
            this._options = options;
        }

        private static void Main(string[] args)
        {
            var options = ReadClAs(args);
            var howManyTimes = HowManyNumbersToPrint();
            var fizzbuzzer = new FizzBuzzProgram(howManyTimes, options);
            foreach (var value in fizzbuzzer)
            {
                Console.WriteLine(value);
            }
        }

        private static Dictionary<string, bool> ReadClAs(string[] args)
        {
            Dictionary<string, bool> options = new Dictionary<string, bool>
            {
                {Fizz, false},
                {Buzz, false},
                {Bang, false},
                {Bong, false},
                {Fezz, false},
                {Rev, false}
            };

            foreach (var arg in args)
            {
                try
                {
                    var num = Convert.ToInt32(arg);
                    switch (num)
                    {
                        case 3:
                            options.Remove(Fizz);
                            options.Add(Fizz, true);
                            break;
                        case 5:
                            options.Remove(Buzz);
                            options.Add(Buzz, true);
                            break;
                        case 7:
                            options.Remove(Bang);
                            options.Add(Bang, true);
                            break;
                        case 11:
                            options.Remove(Bong);
                            options.Add(Bong, true);
                            break;
                        case 13:
                            options.Remove(Fezz);
                            options.Add(Fezz, true);
                            break;
                        case 17:
                            options.Remove(Rev);
                            options.Add(Rev, true);
                            break;
                        default:
                            throw new FormatException();
                    }
                }
                catch (Exception ex) when (ex is FormatException or OverflowException)
                {
                    Console.Error.WriteLine("CLAs were invalid, arguments should each be one of the following numbers: 3, 5, 7, 11, 13, 17.");
                    Environment.Exit(-1);
                }
            }

            return options;
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

        private static string DetermineWords(int number, Dictionary<string, bool> options)
        {
            var multOf3 = IsMultipleOf(number, 3);
            var multOf5 = IsMultipleOf(number, 5);
            var multOf7 = IsMultipleOf(number, 7);
            var multOf11 = IsMultipleOf(number, 11);

            var output = GetFizzBuzzText(number, multOf3, multOf5, multOf7, multOf11, options);
            if (!multOf11 && options[Fezz])
            {
                output = CheckForFezz(output, number);
            }
            
            if (IsMultipleOf(number, 17) && options[Rev])
            {
                output.Reverse();
            }
            
            return string.Join("", output);
        }

        private static List<string> GetFizzBuzzText(int num, bool fizz, bool buzz, bool bang, bool bong, Dictionary<string, bool> options)
        {
            if (bong && options[Bong])
            {
                return new List<string> {Bong};
            }
            
            var words = new List<string>();
            if (fizz && options[Fizz])
            {
                words.Add(Fizz);
            }

            if (buzz && options[Buzz])
            {
                words.Add(Buzz);
            }

            if (bang && options[Bang])
            {
                words.Add(Bang);
            }

            return words.Count == 0 ? new List<string>{"" + num} : words;
        }

        private static List<string> CheckForFezz(List<string> output, int number)
        {
            if (IsMultipleOf(number, 13))
            {
                if (output.Count == 1 && output[0].Equals("" + number))
                {
                    return new List<string>{Fezz};
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
            var index = GetIndexForFezzInsertion(output);
            if (index == -1)
            {
                output.Add(Fezz);
                return output;
            }
            else
            {
                output.Insert(index, Fezz);
                return output;
            }
        }

        private static int GetIndexForFezzInsertion(List<string> output)
        {
            for (var i = 0; i < output.Count; i++)
            {
                var word = output[i];
                if (word[0] == 'B')
                {
                    return i;
                }
            }

            return -1;
        }

        private static bool IsMultipleOf(int number, int factor)
        {
            return number % factor == 0;
        }

        public IEnumerator GetEnumerator()
        {
            for (var i = 1; i <= _limit; i++)
            {
                yield return DetermineWords(i, _options);
            }
        }
    }
}