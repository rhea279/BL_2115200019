
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Convert_CSV_Data
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Marks { get; set; }
        public Student(int id, string name, int age, double marks) {
            ID=id;
            Name=name;
            Age=age;
            Marks=marks;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Age: {Age}, Marks: {Marks}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter CSV File Path:");
            string filePath = Console.ReadLine();
            if (!File.Exists(filePath)) {
                Console.WriteLine("Error: File Not Found");
            }
            List<Student> students = new List<Student>();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    bool isHeader = true;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (isHeader)
                        {
                            isHeader = false;
                            continue;
                        }

                        string[] columns = line.Split(',');
                        if (columns.Length < 4) 
                        {
                            Console.WriteLine("Warning: Skipping invalid record.");
                            continue;
                        }
                        try
                        {
                            int id = int.Parse(columns[0].Trim());
                            string name = columns[1].Trim();
                            int age = int.Parse(columns[2].Trim());
                            double marks = double.Parse(columns[3].Trim(), CultureInfo.InvariantCulture);

                            students.Add(new Student(id, name, age, marks));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Warning: Skipping invalid data format.");
                        }
                    }
                }
                Console.WriteLine("\nList of Students:");
                foreach (Student student in students)
                {
                    Console.WriteLine(student);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
