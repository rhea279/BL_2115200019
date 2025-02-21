
using System;
using System.IO;

namespace Using_using_Statement_for_File_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the source file path:");
                string filePath = Console.ReadLine();
                //Use using to ensure the file is automatically closed after reading
                using (StreamReader sourceStream = new StreamReader(filePath))
                {
                    string firstLine = sourceStream.ReadLine();
                    Console.WriteLine("First Line of file:" + firstLine);
                }
            }
            //If the file does not exist, catch IOException and print "Error reading file"
            catch (IOException)
            {
                Console.WriteLine("Error reading file");
            }
        }
    }
}
