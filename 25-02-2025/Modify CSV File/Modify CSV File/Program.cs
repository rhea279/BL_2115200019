using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;


namespace Modify_CSV_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter File Path of CSV File:");
            string filePath = Console.ReadLine();
            Console.WriteLine("Enter File Path of Updated CSV File:");
            string updateFilePath = Console.ReadLine();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                using (StreamWriter writer = new StreamWriter(updateFilePath))
                {
                    string line;
                    bool isHeader = true;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] columns = line.Split(',');
                        if (isHeader)
                        {
                            writer.WriteLine(line);
                            isHeader = false;
                            continue;
                        }
                        if (columns.Length < 4) 
                        {
                            Console.WriteLine("Warning: Skipping invalid record.");
                            continue;
                        }


                        string id = columns[0].Trim();
                        string name = columns[1].Trim();
                        string department = columns[2].Trim();
                        string salaryStr = columns[3].Trim();


                        if (department.Equals("IT", StringComparison.OrdinalIgnoreCase) &&
                            decimal.TryParse(salaryStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal salary))
                        {
                            salary *= 1.10m;
                            columns[3] = salary.ToString("F2", CultureInfo.InvariantCulture);
                        }
                        writer.WriteLine(string.Join(",", columns));
                    }
                }
                Console.WriteLine("Employee salaries updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
