using System;
using System.Text.RegularExpressions;

class Program
{
    static void ExtractCurrencyValues(string text)
    {
        string pattern = @"\$\s?\d+(\.\d{2})?";
        MatchCollection matches = Regex.Matches(text, pattern);

        if (matches.Count > 0)
        {
            Console.WriteLine("Extracted Currency Values:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
        else
        {
            Console.WriteLine("No currency values found.");
        }
    }

    static void Main()
    {
        Console.Write("Enter text: ");
        string userInput = Console.ReadLine();

        ExtractCurrencyValues(userInput);
    }
}
