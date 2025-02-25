using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter CSV File Path:");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: File not found!");
            return;
        }

        Dictionary<int, string> records = new Dictionary<int, string>();
        HashSet<int> duplicates = new HashSet<int>();

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

                    if (columns.Length < 2) continue; 

                    if (int.TryParse(columns[0].Trim(), out int id))
                    {
                        if (records.ContainsKey(id))
                        {
                            duplicates.Add(id);
                        }
                        else
                        {
                            records[id] = line;
                        }
                    }
                }
            }

            if (duplicates.Count > 0)
            {
                Console.WriteLine("\nDuplicate Records Found:");
                foreach (int id in duplicates)
                {
                    Console.WriteLine(records[id]); 
                }
            }
            else
            {
                Console.WriteLine("\nNo duplicate records found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
