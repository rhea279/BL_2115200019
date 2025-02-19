using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFrequencyCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the file path: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: File not found!");
                return;
            }

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Normalize text: convert to lowercase and remove punctuation
                        line = Regex.Replace(line.ToLower(), @"[^\w\s]", "");

                        string[] words = line.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string word in words)
                        {
                            if (wordCount.ContainsKey(word))
                                wordCount[word]++;
                            else
                                wordCount[word] = 1;
                        }
                    }
                }

                // Display the word frequencies
                Console.WriteLine("\nWord Frequency Count:");
                foreach (var kvp in wordCount.OrderByDescending(k => k.Value))
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }
    }
}
