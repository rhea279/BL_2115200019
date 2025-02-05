using System;
using System.Collections.Generic;

namespace Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set Company Name
            Employee.CompanyName = "Capgemini";
            List<Employee> employees = new List<Employee>();

            while (true)
            {
                //enu Options
                Console.WriteLine("\n ==== Employee Management System ====");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display Employee Details");
                Console.WriteLine("3. Display Total Employees");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose an option : ");

                int choice;
                //Input validation: Ensure choice is between 1 and 4
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid Option! Enter a valid option (1 - 4):");
                }

                switch (choice)
                {
                    case 1:
                        //Add New Employee Details
                        Console.WriteLine("Enter Employee Name :");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter Employee Id :");
                        int id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Employee Designation :");
                        string designation = Console.ReadLine();

                        employees.Add(new Employee(name, id, designation));
                        Console.WriteLine("\nEmployee Details Added Successfully!");
                        break;
                    case 2:
                        //Display Employee Details
                        Console.WriteLine("\nEnter Employee Id to View Details :");
                        int searchNum;
                        while (!int.TryParse(Console.ReadLine(), out searchNum))
                        {
                            Console.WriteLine("Enter a Valid Employee Id!");
                        }
                        Employee employee = employees.Find(e => e.Id == searchNum);
                        if (employee != null)
                        {
                            // Use is operator to check if object is a Patient instance
                            if (employee is Employee)
                            {
                                employee.DisplayEmployeeDetails();
                            }

                        }
                        else
                        {
                            Console.WriteLine("Employee Not Found");
                        }
                        break;
                    case 3:
                        //Display Total number of employees
                        Console.WriteLine("\nTotal Employees"+Employee.DisplayTotalEmployees());
                        break;
                    case 4:
                        //Exit Program
                        Console.WriteLine("\nThank You for using Employee Management System!");
                        return;




                }
            }
        }
        class Employee
        {
            //A static variable CompanyName shared by all employees.
            public static string CompanyName;
            static int totalEmployees = 0;
            public readonly int Id;
            public string Name;
            public string Designation;

            //Use this to initialize Name, Id, and Designation in the constructor.
            public Employee(string Name, int Id, string Designation)
            {
                this.Name = Name;
                this.Id = Id;
                this.Designation = Designation;
                totalEmployees++;
            }
            //A static method to show the total number of employees.
            public static int DisplayTotalEmployees()
            {
                return totalEmployees;
            }
            public void DisplayEmployeeDetails()
            {
                if (this is Employee)
                {
                    Console.WriteLine($"Company Name : {CompanyName}");
                    Console.WriteLine($"Employee Name : {Name}");
                    Console.WriteLine($"Employee id : {Id}");
                    Console.WriteLine($"Employee Designation : {Designation}");
                }
            }
        }
    }
}
