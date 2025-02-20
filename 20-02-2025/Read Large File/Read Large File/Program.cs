using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Enter the path of the large text file: ");
        string filePath = Console.ReadLine();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)  // Read file line by line
                {
                    if (line.IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine(line);  // Print lines containing "error"
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: The specified file was not found.");
        }
        catch (IOException ioEx)
        {
            Console.WriteLine("I/O Error: " + ioEx.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }
}
