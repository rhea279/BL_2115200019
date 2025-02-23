using System;
using System.Text.RegularExpressions;

class Program
{
    static void ExtractLanguages(string text)
    {
        string pattern = @"\b(JavaScript|Java|Python|C\+\+|C#|Go|Swift|Ruby)\b";
        MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

        if (matches.Count > 0)
        {
            Console.WriteLine("Extracted Languages:");
            foreach (Match match in matches)
            {
                Console.Write(match.Value + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No programming languages found.");
        }
    }

    static void Main()
    {
        Console.Write("Enter text: ");
        string userInput = Console.ReadLine();

        ExtractLanguages(userInput);
    }
}
