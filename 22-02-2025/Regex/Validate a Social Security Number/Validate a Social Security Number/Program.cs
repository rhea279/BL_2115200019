using System;
using System.Text.RegularExpressions;

class Program
{
    static bool IsValidSSN(string ssn)
    {
        string pattern = @"^\d{3}-\d{2}-\d{4}$";
        return Regex.IsMatch(ssn, pattern);
    }

    static void Main()
    {
        Console.Write("Enter an SSN: ");
        string input = Console.ReadLine();

        Console.WriteLine(IsValidSSN(input) ? $" \"{input}\" is valid" : $"\"{input}\" is invalid");
    }
}
