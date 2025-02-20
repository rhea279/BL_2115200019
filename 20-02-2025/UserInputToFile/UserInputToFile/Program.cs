using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

[Serializable]
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}

class Program
{
    static string binaryFileName = "employees.dat";
    static string jsonFileName = "employees.json";

    static void Main()
    {
        List<Employee> employees = new List<Employee>();
        Console.Write("Enter the number of employees: ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Employee emp = new Employee();
            Console.Write("Enter Employee ID: ");
            emp.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Employee Name: ");
            emp.Name = Console.ReadLine();
            Console.Write("Enter Employee Department: ");
            emp.Department = Console.ReadLine();
            Console.Write("Enter Employee Salary: ");
            emp.Salary = double.Parse(Console.ReadLine());
            employees.Add(emp);
        }

        try
        {
            SerializeToBinary(employees);
            SerializeToJson(employees);
            Console.WriteLine("Employees saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving employees: " + ex.Message);
        }

        try
        {
            Console.WriteLine("\nLoaded Employees from Binary File:");
            List<Employee> loadedBinaryEmployees = DeserializeFromBinary();
            DisplayEmployees(loadedBinaryEmployees);

            Console.WriteLine("\nLoaded Employees from JSON File:");
            List<Employee> loadedJsonEmployees = DeserializeFromJson();
            DisplayEmployees(loadedJsonEmployees);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading employees: " + ex.Message);
        }
    }

    static void SerializeToBinary(List<Employee> employees)
    {
        using (FileStream fs = new FileStream(binaryFileName, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, employees);
        }
    }

    static List<Employee> DeserializeFromBinary()
    {
        if (!File.Exists(binaryFileName))
            throw new FileNotFoundException("Binary file not found!");

        using (FileStream fs = new FileStream(binaryFileName, FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return (List<Employee>)formatter.Deserialize(fs);
        }
    }

    static void SerializeToJson(List<Employee> employees)
    {
        string jsonString = JsonSerializer.Serialize(employees);
        File.WriteAllText(jsonFileName, jsonString);
    }

    static List<Employee> DeserializeFromJson()
    {
        if (!File.Exists(jsonFileName))
            throw new FileNotFoundException("JSON file not found!");

        string jsonString = File.ReadAllText(jsonFileName);
        return JsonSerializer.Deserialize<List<Employee>>(jsonString);
    }

    static void DisplayEmployees(List<Employee> employees)
    {
        foreach (var emp in employees)
        {
            Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
        }
    }
}
