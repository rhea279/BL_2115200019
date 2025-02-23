using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void FindRepeatingWords(string text)
    {
        string pattern = @"\b(\w+)\b(?=.*\b\1\b)";
        MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

        HashSet<string> repeatingWords = new HashSet<string>();
        foreach (Match match in matches)
        {
            repeatingWords.Add(match.Value);
        }

        Console.WriteLine("Repeating Words: " + string.Join(", ", repeatingWords));
    }

    static void Main()
    {
        Console.Write("Enter a sentence: ");
        string userInput = Console.ReadLine();

        FindRepeatingWords(userInput);
    }
}
