
using System;

namespace Handling_Invalid_Input_in_Interest_Calculation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Amount:");
            double amount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Rate of Interest:");
            double rate = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Number of Years:");
            int years = Convert.ToInt32(Console.ReadLine());

            try
            {
                double interest = CalculateInterest(amount, rate, years);
                Console.WriteLine($"Calculated Interest: {interest}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Invalid input: {ex.Message}");
            }
        }
        static double CalculateInterest(double amount, double rate, int years) {
            if (amount < 0 || rate < 0)
            {
                throw new ArgumentException("Invalid Input: Amount and Rate must be positive");
            }
            return amount*rate*years;
        }
    }
}
