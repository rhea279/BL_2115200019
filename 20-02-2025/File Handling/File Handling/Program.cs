using System;
using System.IO;

namespace File_Handling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter source file path: ");
            string sourceFilePath = Console.ReadLine();
            Console.Write("Enter destination file path: ");
            string destinationFilePath = Console.ReadLine();

            try
            {
                if (!File.Exists(sourceFilePath))
                {
                    Console.WriteLine("Error:Source file does not exist.");
                    return;
                }
                using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
                using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024];
                    int byteRead;
                    while ((byteRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destinationStream.Write(buffer, 0, byteRead);
                    }
                }
                Console.WriteLine("File copied successfully.");
            }
            catch (IOException ioEx) {
                Console.WriteLine("I/O Error:" + ioEx.Message);
            }
            catch (Exception ex) {
                Console.WriteLine("Unexpected Error:" + ex.Message);
            }

        }
    }
}
