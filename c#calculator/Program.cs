using System;

namespace AdvancedCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;
            Console.WriteLine("=== Advanced C# Calculator ===");

            while (keepRunning)
            {
                // Display Menu of Options
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Add (+)");
                Console.WriteLine("2. Subtract (-)");
                Console.WriteLine("3. Multiply (*)");
                Console.WriteLine("4. Divide (/)");
                Console.WriteLine("5. Square a number (x²)");
                Console.WriteLine("6. Square Root (√x)");
                Console.WriteLine("7. Power/Exponent (x^y)");
                Console.WriteLine("8. Sine (sin)");
                Console.WriteLine("9. Cosine (cos)");
                Console.WriteLine("10. Tangent (tan)");
                Console.Write("Enter choice (1-10): ");

                string choice = Console.ReadLine();
                double num1 = 0, num2 = 0, result = 0;
                bool validChoice = true;

                // Handle operations that only need ONE number
                if (choice == "5" || choice == "6" || choice == "8" || choice == "9" || choice == "10")
                {
                    Console.Write("Enter the number: ");
                    if (!double.TryParse(Console.ReadLine(), out num1))
                    {
                        Console.WriteLine("Invalid input.");
                        continue;
                    }

                    switch (choice)
                    {
                        case "5": // Square
                            result = Math.Pow(num1, 2);
                            Console.WriteLine($"Result: {num1} squared = {result}");
                            break;
                        case "6": // Square Root
                            if (num1 < 0)
                            {
                                Console.WriteLine("Error: Cannot take the square root of a negative number!");
                                validChoice = false;
                            }
                            else
                            {
                                result = Math.Sqrt(num1);
                                Console.WriteLine($"Result: Square root of {num1} = {result}");
                            }
                            break;
                        case "8": // Sin (expects radians, so we convert from degrees)
                            result = Math.Sin(num1 * Math.PI / 180);
                            Console.WriteLine($"Result: sin({num1}°) = {result}");
                            break;
                        case "9": // Cos
                            result = Math.Cos(num1 * Math.PI / 180);
                            Console.WriteLine($"Result: cos({num1}°) = {result}");
                            break;
                        case "10": // Tan
                            result = Math.Tan(num1 * Math.PI / 180);
                            Console.WriteLine($"Result: tan({num1}°) = {result}");
                            break;
                    }
                }
                // Handle operations that need TWO numbers
                else if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "7")
                {
                    Console.Write("Enter the first number: ");
                    if (!double.TryParse(Console.ReadLine(), out num1)) { Console.WriteLine("Invalid input."); continue; }

                    Console.Write("Enter the second number: ");
                    if (!double.TryParse(Console.ReadLine(), out num2)) { Console.WriteLine("Invalid input."); continue; }

                    switch (choice)
                    {
                        case "1":
                            result = num1 + num2;
                            Console.WriteLine($"Result: {num1} + {num2} = {result}");
                            break;
                        case "2":
                            result = num1 - num2;
                            Console.WriteLine($"Result: {num1} - {num2} = {result}");
                            break;
                        case "3":
                            result = num1 * num2;
                            Console.WriteLine($"Result: {num1} * {num2} = {result}");
                            break;
                        case "4":
                            if (num2 == 0)
                            {
                                Console.WriteLine("Error: Cannot divide by zero.");
                                validChoice = false;
                            }
                            else
                            {
                                result = num1 / num2;
                                Console.WriteLine($"Result: {num1} / {num2} = {result}");
                            }
                            break;
                        case "7": // Power (x to the power of y)
                            result = Math.Pow(num1, num2);
                            Console.WriteLine($"Result: {num1} to the power of {num2} = {result}");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid menu choice.");
                    validChoice = false;
                }

                // Ask to continue
                Console.Write("\nWould you like to do another calculation? (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                {
                    keepRunning = false;
                }
            }

            Console.WriteLine("\nGoodbye!");
        }
    }
}