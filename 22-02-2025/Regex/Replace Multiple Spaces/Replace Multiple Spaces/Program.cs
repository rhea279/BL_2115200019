using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Enter a sentence: ");
        string input = Console.ReadLine();

        string output = Regex.Replace(input, @"\s+", " ");
        Console.WriteLine("Modified String: " + output);
    }
}
