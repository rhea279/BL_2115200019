using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Enter the path of the text file: ");
        string filePath = Console.ReadLine();

        try
        {
            Dictionary<string, int> wordCount = CountWordsInFile(filePath);

            Console.WriteLine($"\nTotal Words: {wordCount.Values.Sum()}");
            Console.WriteLine("\nTop 5 Most Frequent Words:");

            foreach (var word in wordCount.OrderByDescending(w => w.Value).Take(5))
            {
                Console.WriteLine($"{word.Key}: {word.Value} times");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: The specified file was not found.");
        }
        catch (IOException ioEx)
        {
            Console.WriteLine("I/O Error: " + ioEx.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }

    static Dictionary<string, int> CountWordsInFile(string filePath)
    {
        Dictionary<string, int> wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        char[] delimiters = { ' ', '\t', '\r', '\n', '.', ',', '!', '?', ';', ':', '\"', '(', ')', '[', ']', '{', '}', '-', '_', '/' };

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    string cleanedWord = Regex.Replace(word.ToLower(), "[^a-zA-Z0-9]", ""); // Remove special characters

                    if (!string.IsNullOrWhiteSpace(cleanedWord))
                    {
                        if (wordCount.ContainsKey(cleanedWord))
                            wordCount[cleanedWord]++;
                        else
                            wordCount[cleanedWord] = 1;
                    }
                }
            }
        }
        return wordCount;
    }
}
