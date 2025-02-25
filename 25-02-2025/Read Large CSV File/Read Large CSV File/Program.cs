using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter CSV File Path:");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("❌ Error: File not found!");
            return;
        }

        int batchSize = 100;  // Process 100 lines at a time
        int totalRecords = 0;
        int batchCount = 0;

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool isHeader = true;
                int lineCount = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (isHeader)  // Skip header row
                    {
                        isHeader = false;
                        continue;
                    }

                    // Process each line (Example: Just count the lines)
                    totalRecords++;
                    lineCount++;

                    if (lineCount == batchSize)
                    {
                        batchCount++;
                        Console.WriteLine($"Processed Batch {batchCount}: {totalRecords} records so far...");
                        lineCount = 0;
                    }
                }

                // Final status update
                Console.WriteLine($"Finished processing {totalRecords} records!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
