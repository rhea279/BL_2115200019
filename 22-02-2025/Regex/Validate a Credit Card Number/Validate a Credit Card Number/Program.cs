using System;
using System.Text.RegularExpressions;

class Program
{
    static bool IsValidCreditCard(string cardNumber)
    {
        string pattern = @"^(4\d{15}|5[1-5]\d{14})$";
        return Regex.IsMatch(cardNumber, pattern);
    }

    static void Main()
    {
        Console.Write("Enter a credit card number: ");
        string input = Console.ReadLine();

        Console.WriteLine(IsValidCreditCard(input) ? "Valid Card" : "Invalid Card");
    }
}
