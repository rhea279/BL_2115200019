
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Sort_CSV_Records
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter CSV File Path:");
            string filePath = Console.ReadLine();
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File Not Found");
                return;
            }
            try
            {
                List<(string ID, string Name, string Department, decimal Salary)> employees = new List<(string, string, string, decimal)>();

                using (StreamReader str = new StreamReader(filePath))
                {
                    string line = str.ReadLine();
                    bool isHeader = true;
                    while ((line = str.ReadLine()) != null)
                    {
                        if (isHeader)
                        {
                            isHeader = false;
                            continue;
                        }

                        string[] columns = line.Split(',');
                        string id = columns[0].Trim();
                        string name = columns[1].Trim();
                        string department = columns[2].Trim();
                        string salaryStr = columns[3].Trim();

                        if (decimal.TryParse(salaryStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal salary))
                        {
                            employees.Add((id, name, department, salary));
                        }
                        else
                        {
                            Console.WriteLine($"Warning: Skipping record with invalid salary for {name}.");
                        }
                    }
                }
                var sortedEmployees = employees.OrderByDescending(emp => emp.Salary).Take(5).ToList();

                Console.WriteLine("\nTop 5 Highest Paid Employees:");
                Console.WriteLine("--------------------------------------");
                foreach (var emp in sortedEmployees)
                {
                    Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary:C}");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}