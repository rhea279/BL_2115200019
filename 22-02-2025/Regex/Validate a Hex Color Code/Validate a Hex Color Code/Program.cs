using System;
using System.Text.RegularExpressions;

class Program
{
    static bool IsValidHexColor(string color)
    {
        string pattern = @"^#([A-Fa-f0-9]{6})$";
        return Regex.IsMatch(color, pattern);
    }

    static void Main()
    {
        Console.Write("Enter a hex color code: ");
        string userInput = Console.ReadLine();

        if (IsValidHexColor(userInput))
        {
            Console.WriteLine("Valid hex color code.");
        }
        else
        {
            Console.WriteLine("Invalid hex color code.");
        }
    }
}
