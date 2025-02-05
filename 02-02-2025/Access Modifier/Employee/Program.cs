using System;

// Employee class with different access levels for fields
public class Employee
{
    public int EmployeeID;  // public field
    protected string Department;  // protected field
    private double Salary;  // private field

    // Constructor to initialize employee details
    public Employee(int employeeID, string department, double salary)
    {
        EmployeeID = employeeID;
        Department = department;
        Salary = salary;
    }

    // Public method to modify the salary
    public void ModifySalary(double newSalary)
    {
        Salary = newSalary;
    }

    // Method to get the salary (since it's private)
    public double GetSalary()
    {
        return Salary;
    }

    // Method to display employee details
    public void DisplayEmployeeDetails()
    {
        Console.WriteLine($"Employee ID: {EmployeeID}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Salary: {Salary:C}");
    }
}

// Manager subclass accessing Employee details
public class Manager : Employee
{
    // Constructor to initialize Manager details
    public Manager(int employeeID, string department, double salary)
        : base(employeeID, department, salary)
    {
    }

    // Method to display Manager's details, accessing inherited fields
    public void DisplayManagerDetails()
    {
        Console.WriteLine($"Manager's Employee ID: {EmployeeID}");
        Console.WriteLine($"Manager's Department: {Department}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Taking input for Employee details
        Console.Write("Enter Employee ID: ");
        int employeeID = int.Parse(Console.ReadLine());

        Console.Write("Enter Employee Department: ");
        string department = Console.ReadLine();

        Console.Write("Enter Employee Salary: ");
        double salary = double.Parse(Console.ReadLine());

        // Create an Employee object
        Employee employee = new Employee(employeeID, department, salary);

        // Display Employee details
        Console.WriteLine("\nEmployee Details:");
        employee.DisplayEmployeeDetails();

        // Modify salary and display updated details
        Console.Write("\nEnter new salary to modify: ");
        double newSalary = double.Parse(Console.ReadLine());
        employee.ModifySalary(newSalary);

        Console.WriteLine("\nUpdated Employee Details:");
        employee.DisplayEmployeeDetails();

        // Create a Manager object
        Manager manager = new Manager(employeeID, department, salary);

        // Display Manager details
        Console.WriteLine("\nManager Details:");
        manager.DisplayManagerDetails();
    }
}
