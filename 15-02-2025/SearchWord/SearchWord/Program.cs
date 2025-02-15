using System;

namespace SearchWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size array:");
            int size = Convert.ToInt32(Console.ReadLine());

            string[] sentences = new string[size];
            for (int i = 0; i < sentences.Length; i++)
            {
                Console.WriteLine($"Enter the {i + 1} sentence of array:");
                sentences[i] = Console.ReadLine();
            }
            Console.WriteLine("Enter a word to search:");
            string wordToSearch = Console.ReadLine();
            string result = SearchSpecificWord(sentences, wordToSearch);
            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine($"the first sentence containing a specific word '{wordToSearch}' is {result}");
            }
            else
            {
                Console.WriteLine("No sentence has this word.");
            }
        }
        public static string SearchSpecificWord(string[] sentences, string wordToSearch)
        {
            foreach (string s in sentences)
            {
                if (s.IndexOf(wordToSearch,StringComparison.OrdinalIgnoreCase)>=0)
                {
                    return s;
                }
            }
            return string.Empty;
        }
    }
}
