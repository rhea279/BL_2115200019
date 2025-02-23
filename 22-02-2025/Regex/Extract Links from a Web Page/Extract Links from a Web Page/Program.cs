using System;
using System.Text.RegularExpressions;

class Program
{
    static void ExtractLinks(string text)
    {
        string pattern = @"https?://[^\s]+";
        MatchCollection matches = Regex.Matches(text, pattern);

        if (matches.Count > 0)
        {
            Console.WriteLine("Extracted Links:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
        else
        {
            Console.WriteLine("No links found.");
        }
    }

    static void Main()
    {
        Console.Write("Enter text: ");
        string userInput = Console.ReadLine();

        ExtractLinks(userInput);
    }
}
