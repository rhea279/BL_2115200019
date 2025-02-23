using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string[] badWords = { "damn", "stupid" };

        Console.Write("Enter a sentence: ");
        string input = Console.ReadLine();

        foreach (string badWord in badWords)
        {
            input = Regex.Replace(input, @"\b" + badWord + @"\b", "****", RegexOptions.IgnoreCase);
        }

        Console.WriteLine("Censored Output: " + input);
    }
}
