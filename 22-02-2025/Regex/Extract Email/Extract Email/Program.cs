
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace Extract_Email
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string userInput = Console.ReadLine();
            ExtractEmail(userInput);
        }
        static void ExtractEmail(string input)
        {
            string pattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
            MatchCollection matches = Regex.Matches(input, pattern);

            if (matches.Count > 0)
            {
                Console.WriteLine("Extracted Email Addresses:");
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("No email addresses found.");
            }
        }
    }
}
