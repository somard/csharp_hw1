using System;

namespace BooleanLogicCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Boolean Logic Calculator!");

            while (true)
            {
                // Request operation from the user
                Console.WriteLine("Choose an operation: AND, OR, NOT or type 'exit' to quit");
                string operation = Console.ReadLine().ToUpper();

                // Exit condition
                if (operation == "EXIT")
                {
                    break;
                }

                bool result;

                switch (operation)
                {
                    case "AND":
                        // Request two boolean values from the user for AND operation
                        Console.WriteLine("Enter the first boolean value (true/false):");
                        bool andValue1 = Convert.ToBoolean(Console.ReadLine());

                        Console.WriteLine("Enter the second boolean value (true/false):");
                        bool andValue2 = Convert.ToBoolean(Console.ReadLine());

                        result = And(andValue1, andValue2);
                        Console.WriteLine($"Result: {andValue1} AND {andValue2} = {result}");
                        break;
                    case "OR":
                        // Request two boolean values from the user for OR operation
                        Console.WriteLine("Enter the first boolean value (true/false):");
                        bool orValue1 = Convert.ToBoolean(Console.ReadLine());

                        Console.WriteLine("Enter the second boolean value (true/false):");
                        bool orValue2 = Convert.ToBoolean(Console.ReadLine());

                        result = Or(orValue1, orValue2);
                        Console.WriteLine($"Result: {orValue1} OR {orValue2} = {result}");
                        break;
                    case "NOT":
                        // Request one boolean value from the user for NOT operation
                        Console.WriteLine("Enter the boolean value (true/false):");
                        bool notValue = Convert.ToBoolean(Console.ReadLine());

                        result = Not(notValue);
                        Console.WriteLine($"Result: NOT {notValue} = {result}");
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

            Console.WriteLine("Thank you for using the Boolean Logic Calculator!");
        }

        static bool And(bool value1, bool value2)
        {
            return value1 && value2;
        }

        static bool Or(bool value1, bool value2)
        {
            return value1 || value2;
        }

        static bool Not(bool value)
        {
            return !value;
        }
    }
}
