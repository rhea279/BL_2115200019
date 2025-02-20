using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Enter the path of the source text file: ");
        string sourceFilePath = Console.ReadLine();

        Console.Write("Enter the path to save the modified text file: ");
        string destinationFilePath = Console.ReadLine();

        try
        {
            ConvertUppercaseToLowercase(sourceFilePath, destinationFilePath);
            Console.WriteLine("File conversion successful! All uppercase letters converted to lowercase.");
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

    static void ConvertUppercaseToLowercase(string sourcePath, string destinationPath)
    {
        if (!File.Exists(sourcePath))
            throw new FileNotFoundException("Source file not found!");

        // Open files with BufferedStream for efficiency
        using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
        using (BufferedStream bufferedSource = new BufferedStream(sourceStream))
        using (StreamReader reader = new StreamReader(bufferedSource, Encoding.UTF8))

        using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
        using (BufferedStream bufferedDestination = new BufferedStream(destinationStream))
        using (StreamWriter writer = new StreamWriter(bufferedDestination, Encoding.UTF8))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                writer.WriteLine(line.ToLower()); // Convert to lowercase
            }
        }
    }
}
