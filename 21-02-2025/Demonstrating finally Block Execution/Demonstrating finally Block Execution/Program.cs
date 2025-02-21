using System;
namespace Demonstrating_finally_Block_Execution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter First Number:");
                int n1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Second Number:");
                int n2 = Convert.ToInt32(Console.ReadLine());

                //If the user enters valid numbers, print the result of the division
                int result = n1 / n2;
                Console.WriteLine($"Dividing {n1} by {n2} = {result}");

            }
            //If the user enters 0 as the denominator, catch and handle DivideByZeroException
            catch (DivideByZeroException ex1)
            {
                Console.WriteLine(ex1.Message);
            }
            //Ensure "Operation completed" is always printed using finally
            finally
            {
                Console.WriteLine("Operation completed");
            }
        }

    }
}
