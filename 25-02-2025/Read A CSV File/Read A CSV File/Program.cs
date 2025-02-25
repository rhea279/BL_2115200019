
using System;
using System.IO;

namespace Read_A_CSV_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the file path:");
                string filepath = Console.ReadLine();
                if (!File.Exists(filepath))
                {
                    Console.WriteLine("Error: File Not Found");
                    return;
                }
                using (StreamReader str = new StreamReader(filepath))
                {
                    string line;
                    while ((line = str.ReadLine()) != null)
                    {
                        string[] columns = line.Split(',');
                        Console.WriteLine($"ID:{columns[0]}\nName:{columns[1]}\nAge:{columns[2]}\nMarks:{columns[3]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
