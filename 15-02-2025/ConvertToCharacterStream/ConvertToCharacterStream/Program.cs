using System;
using System.IO;
using System.Text;

namespace ConvertToCharacterStream
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get file path from user
            Console.WriteLine("Enter the file path:");
            string filePath = Console.ReadLine();
            try
            {
                // Convert byte stream to character stream
                ReadBinaryFileAsText(filePath);
            }
            catch(Exception ex) { 
                Console.WriteLine(ex.ToString());
            }
        }
        // Method to read binary data and convert it to text
        public static void ReadBinaryFileAsText(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine("File Content:\n" + content);
            }
        }
    }
}
