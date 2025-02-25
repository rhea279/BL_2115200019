
using System;
using System.IO;

namespace Write_Data_in_CSV_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter File Path of CSV File:");
            string filePath = Console.ReadLine();
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    Console.WriteLine("Enter Employee Details:ID,Name,Department,Salary:");
                    int n = 5;
                    while (n > 0)
                    {
                        writer.WriteLine(Console.ReadLine());
                        n--;
                    }

                }
                Console.WriteLine("CSV File Written Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
