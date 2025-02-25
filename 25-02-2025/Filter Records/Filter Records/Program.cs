
using System;
using System.IO;

namespace Filter_Records
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter File Path of CSV File:");
            string filePath = Console.ReadLine();
            try
            {
                using (StreamReader str = new StreamReader(filePath))
                {
                    string line;
                    bool isHeader = true;
                    bool found = true;

                    Console.WriteLine("\nStudents with marks > 80:");
                    while ((line = str.ReadLine()) != null)
                    {
                        if (isHeader)
                        {
                            isHeader = false;
                            continue;
                        }
                        string[] columns = line.Split(',');
                        if (columns.Length < 4)
                        {
                            Console.WriteLine("Warning: Skipping Invalid Record");
                            continue;
                        }
                        if (int.TryParse(columns[3].Trim(), out int marks) && marks > 80)
                        {
                            Console.WriteLine($"ID: {columns[0].Trim()} | Name: {columns[1].Trim()} | Age: {columns[2].Trim()} | Marks: {marks}");
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("No student has marks above 80");
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
