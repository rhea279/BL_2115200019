
using System;

namespace Propagating_Exceptions_Across_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Method2();
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine($"Handled exception in Main: {ex.Message}");
            }
        }
        static void Method2()
        {
             Method1();
        }
        static void Method1()
        {
            int numerator = 10;
            int denominator = 0;
            int result = numerator / denominator;
        }
    }
}
