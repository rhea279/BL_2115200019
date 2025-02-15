using System;
using System.IO;
using System.Security.Authentication;

namespace OccurrenceOfWord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input the file path
            Console.WriteLine("Enter File Path:");
            string filePath = Console.ReadLine();
            //Input the word to find its number of occurrrences
            Console.WriteLine("Enter the word to count:");
            string wordToFind = Console.ReadLine();
            try
            {
                int count = CountOccurrences(filePath, wordToFind);
                Console.WriteLine($"The word '{wordToFind} appers {count} times in the file");
            }
            catch (IOException ex) {
                Console.WriteLine(ex.ToString());
            }
        }
        //Method to find the occurrence of word
        public static int CountOccurrences(string filePath, string wordToFind)
        {
            int count = 0;
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ' ', ',', '.', '|', '?', ',', ';', ':', '-', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        if (word.Equals(wordToFind, StringComparison.OrdinalIgnoreCase))
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
