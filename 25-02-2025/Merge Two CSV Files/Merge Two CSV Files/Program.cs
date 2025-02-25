using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Merge_Two_CSV_Files
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Marks { get; set; } = -1;  // Default value for missing data
        public string Grade { get; set; } = "N/A";  // Default value for missing data
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter File 1 Path (students1.csv):");
            string filePath1 = Console.ReadLine();
            Console.WriteLine("Enter File 2 Path (students2.csv):");
            string filePath2 = Console.ReadLine();
            Console.WriteLine("Enter Path for merged output file:");
            string outputFile = Console.ReadLine();

            // Validate file existence
            if (!File.Exists(filePath1) || !File.Exists(filePath2))
            {
                Console.WriteLine("Error: One or both files not found!");
                return;
            }

            Dictionary<int, Student> students = new Dictionary<int, Student>();

            try
            {
                // Read first CSV file (students1.csv)
                using (StreamReader reader = new StreamReader(filePath1))
                {
                    string line;
                    bool isHeader = true;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (isHeader) { isHeader = false; continue; }

                        string[] columns = line.Split(',');
                        if (columns.Length < 3) continue; // Skip invalid rows

                        if (int.TryParse(columns[0].Trim(), out int id) &&
                            int.TryParse(columns[2].Trim(), out int age))
                        {
                            string name = columns[1].Trim();
                            students[id] = new Student { ID = id, Name = name, Age = age };
                        }
                        else
                        {
                            Console.WriteLine($"⚠ Warning: Skipping invalid row in {filePath1}");
                        }
                    }
                }

                // Read second CSV file (students2.csv)
                using (StreamReader reader = new StreamReader(filePath2))
                {
                    string line;
                    bool isHeader = true;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (isHeader) { isHeader = false; continue; }

                        string[] columns = line.Split(',');
                        if (columns.Length < 3) continue; // Skip invalid rows

                        if (int.TryParse(columns[0].Trim(), out int id) &&
                            double.TryParse(columns[1].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double marks))
                        {
                            string grade = columns[2].Trim();

                            if (students.ContainsKey(id))
                            {
                                students[id].Marks = marks;
                                students[id].Grade = grade;
                            }
                            else
                            {
                                students[id] = new Student { ID = id, Marks = marks, Grade = grade };
                            }
                        }
                        else
                        {
                            Console.WriteLine($"⚠ Warning: Skipping invalid row in {filePath2}");
                        }
                    }
                }

                // Write merged data to output CSV file
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    writer.WriteLine("ID,Name,Age,Marks,Grade");
                    foreach (var student in students.Values)
                    {
                        writer.WriteLine($"{student.ID},{student.Name},{student.Age},{student.Marks},{student.Grade}");
                    }
                }

                Console.WriteLine("Merging completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
