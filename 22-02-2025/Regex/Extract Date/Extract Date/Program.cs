using System;
using System.Text.RegularExpressions;

class Program
{
    static void ExtractDates(string text)
    {
        string pattern = @"\b\d{2}/\d{2}/\d{4}\b";
        MatchCollection matches = Regex.Matches(text, pattern);

        if (matches.Count > 0)
        {
            Console.WriteLine("Extracted Dates:");
            foreach (Match match in matches)
            {
                Console.Write(match.Value + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No dates found.");
        }
    }

    static void Main()
    {
        Console.Write("Enter text: ");
        string userInput = Console.ReadLine();

        ExtractDates(userInput);
    }
}
