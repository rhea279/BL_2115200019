using System;
using System.IO;

namespace StreamReaderFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter File Path:");
            string filePath = Console.ReadLine();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                        Console.WriteLine(line);
                }
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
