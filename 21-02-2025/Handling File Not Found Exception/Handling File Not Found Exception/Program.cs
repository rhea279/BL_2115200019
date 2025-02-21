using System;
using System.IO;

namespace Handling_File_Not_Found_Exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Source File Path:");
            string filePath = Console.ReadLine();
            try
            {
                string content= File.ReadAllText(filePath);
                Console.WriteLine("File Contents:\n"+content);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine("File Not Found" + ioEx.Message);
        }
        }
    }
}
