using System;

namespace BitwiseOperatorsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bitwise Operators Calculator!");

            while (true)
            {
                Console.WriteLine("Choose an operation: AND, OR, NOT or type 'exit' to quit");
                string operation = Console.ReadLine().ToUpper();

                // Exit condition
                if (operation == "EXIT")
                {
                    break;
                }

                switch (operation)
                {
                    case "AND":
                        ProcessBitwiseOperation(operation, "&");
                        break;
                    case "OR":
                        ProcessBitwiseOperation(operation, "|");
                        break;
                    case "NOT":
                        ProcessBitwiseNotOperation();
                        break;
                    default:
                        Console.WriteLine("Invalid operation, please try again.");
                        break;
                }

                Console.WriteLine("Do you want to perform another operation? (yes/no)");
                string answer = Console.ReadLine();
                if (!answer.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }

            Console.WriteLine("Thank you for using the Bitwise Operators Calculator!");
        }

        static void ProcessBitwiseOperation(string operation, string symbol)
        {
            Console.WriteLine($"Enter numbers separated by spaces for {operation} operation:");
            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int result = numbers[0];

            foreach (int number in numbers)
            {
                result = symbol == "&" ? result & number : result | number;
            }

            Console.WriteLine($"Result: {string.Join($" {symbol} ", numbers)} = {result}");
        }

        static void ProcessBitwiseNotOperation()
        {
            Console.WriteLine("Enter a number for NOT operation:");
            int number = Convert.ToInt32(Console.ReadLine());
            int result = ~number;

            Console.WriteLine($"Result: ~{number} = {result}");
        }
    }
}
