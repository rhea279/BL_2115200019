
using System.Text.RegularExpressions;
using System;

namespace Extract_Capital_Letters
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter a sentence: ");
            string userInput = Console.ReadLine();

            ExtractCapitalizedWords(userInput);
        }
        static void ExtractCapitalizedWords(string text)
        {
            string pattern = @"\b[A-Z][a-z]*\b";
            MatchCollection matches = Regex.Matches(text, pattern);

            if (matches.Count > 0)
            {
                Console.WriteLine("Extracted Capitalized Words:");
                foreach (Match match in matches)
                {
                    Console.Write(match.Value + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No capitalized words found.");
            }
        }
    }
}
