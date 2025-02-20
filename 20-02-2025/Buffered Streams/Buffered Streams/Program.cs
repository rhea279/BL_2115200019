using System;
using System.Diagnostics;
using System.IO;

namespace Buffered_Streams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Source File Path:");
            string sourceFilePath = Console.ReadLine();
            Console.WriteLine("Enter the destination file path (Buffered Copy):");
            string destinationBFilePath = Console.ReadLine();
            Console.WriteLine("Enter the destination file path (Unbuffered Copy):");
            string destinationUFilePath = Console.ReadLine();


            try
            {
                //Buffered Stream Copy
                if (!File.Exists(sourceFilePath))
                {
                    Console.WriteLine("Error:Source file does not exist.");
                    return;
                }
                Stopwatch sw = new Stopwatch();
                sw.Start();
                using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
                using (FileStream destinationUStream = new FileStream(destinationBFilePath, FileMode.Create, FileAccess.Write))
                using (BufferedStream bufferedStream = new BufferedStream(destinationUStream, 4096))
                {
                    byte[] bytes = new byte[4096];
                    int bytesRead;
                    while ((bytesRead = sourceStream.Read(bytes, 0, bytes.Length)) > 0)
                    {
                        bufferedStream.Write(bytes, 0, bytesRead);
                    }
                }
                sw.Stop();
                Console.WriteLine("buffered Copy Time:" + sw.ElapsedMilliseconds + "ms");
                // Unbuffered Stream Copy
                sw.Restart();
                using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
                using (FileStream destinationStream = new FileStream(destinationUFilePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destinationStream.Write(buffer, 0, bytesRead);
                    }
                }
                sw.Stop();
                Console.WriteLine($"Unbuffered Copy Time: {sw.ElapsedMilliseconds} ms");

            }
            
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }


          }
    }
}
