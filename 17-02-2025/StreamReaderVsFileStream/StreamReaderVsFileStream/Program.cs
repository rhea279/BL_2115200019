using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StreamReaderVsFileStream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Performance Comparison: `StreamReader` vs `FileStream`\n");

            string[] datasetSizes = { "1MB.txt", "100MB.txt", "500MB.txt" };

            foreach (string file in datasetSizes)
            {
                Console.WriteLine($"Testing with {file}...");

                // Measure StreamReader Performance
                Stopwatch sw1 = Stopwatch.StartNew();
                ReadUsingStreamReader(file);
                sw1.Stop();
                Console.WriteLine($"StreamReader Time: {sw1.ElapsedMilliseconds} ms");

                // Measure FileStream Performance
                Stopwatch sw2 = Stopwatch.StartNew();
                ReadUsingFileStream(file);
                sw2.Stop();
                Console.WriteLine($"FileStream Time: {sw2.ElapsedMilliseconds} ms");
                Console.WriteLine("--------------------------------------");
            }
        }

        public static void ReadUsingStreamReader(string file)
        {
            using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
            {
                while (sr.Read() != -1) { } // Reading character by character
            }
        }

        public static void ReadUsingFileStream(string filePath)
        {
            byte[] buffer = new byte[8192]; // Read in 8KB chunks for efficiency
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                while (fs.Read(buffer, 0, buffer.Length) > 0) { }
            }
        }
    }
}
