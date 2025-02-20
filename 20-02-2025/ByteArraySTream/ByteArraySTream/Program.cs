
using System;
using System.IO;

namespace ByteArrayStream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the path of the image file to read: ");
            string sourcePath = Console.ReadLine();

            Console.Write("Enter the path to save the new image file: ");
            string destinationPath = Console.ReadLine();
            try
            {
                byte[] imageData = FileToByteArray(sourcePath);
                ByteArrayToFile(destinationPath, imageData);
                Console.WriteLine("Image Successfully converted");
            }
            catch (IOException ioEx)
            {
                Console.WriteLine("I/O Error:" + ioEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        static byte[] FileToByteArray(string filePath)
        {
            if(!File.Exists(filePath)) 
                throw new FileNotFoundException("Source file not found");
            return File.ReadAllBytes(filePath);

        }
        static void ByteArrayToFile(string filePath, byte[] imageData)
        {
            File.WriteAllBytes(filePath, imageData);
        }
    }
}
