using System;
using System.IO;

class Program
{

    static string filePath;
    static void Main()
    {
        Console.Write("Enter the path of the source text file: ");
        filePath = Console.ReadLine();

        Console.Write("Enter the number of students: ");
        int numStudents = int.Parse(Console.ReadLine());

        // Write student details to binary file
        try
        {
            StoreStudentData(numStudents);
            Console.WriteLine("Student details saved successfully!");
        }
        catch (IOException ioEx)
        {
            Console.WriteLine("I/O Error: " + ioEx.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }

        // Read and display student details
        try
        {
            Console.WriteLine("\nRetrieving student details from file:");
            RetrieveStudentData();
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

    static void StoreStudentData(int count)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write("\nEnter Roll Number: ");
                int rollNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter GPA: ");
                double gpa = double.Parse(Console.ReadLine());

                // Writing data to file
                writer.Write(rollNumber);
                writer.Write(name);
                writer.Write(gpa);
            }
        }
    }

    static void RetrieveStudentData()
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Student data file not found!");

        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            while (fs.Position < fs.Length) // Ensure we don't read past the file end
            {
                int rollNumber = reader.ReadInt32();
                string name = reader.ReadString();
                double gpa = reader.ReadDouble();

                Console.WriteLine($"Roll No: {rollNumber}, Name: {name}, GPA: {gpa}");
            }
        }
    }
}
