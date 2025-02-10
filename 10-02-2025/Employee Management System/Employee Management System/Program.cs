using System;
using System.Collections.Generic;
namespace Employee_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            Console.WriteLine("Enter number of employees :");
            int numOfEmployees = int.Parse(Console.ReadLine());

            for(int i = 0; i< numOfEmployees; i++) {
                Console.WriteLine("\nEnter Employee Type(FullTime/PartTime):");
                string type = Console.ReadLine();

                Console.WriteLine("Enter Employee Id:");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Employee Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Department: ");
                string department = Console.ReadLine();

                if (type.Equals("FullTime", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Enter Base Salary:");
                    double baseSalary = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Bonus:");
                    double bonus = double.Parse(Console.ReadLine());

                    FullTimeEmployee emp = new FullTimeEmployee(id, name, baseSalary, bonus);
                    emp.AssignDepartment(department);
                    employees.Add(emp);
                }
                else if (type.Equals("PartTime", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Enter Hours Worked:");
                    int hoursWorked = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Hourly Rate:");
                    double hours = double.Parse(Console.ReadLine());

                    PartTimeEmployee partEmp = new PartTimeEmployee(id, name, hoursWorked, hours);
                    partEmp.AssignDepartment(department);
                    employees.Add(partEmp);
                }
                else
                {
                    Console.WriteLine("Invalid Employee Type!");
                }
                //Display Employee Details
                foreach (var employee in employees)
                {
                    employee.DisplayDetails();
                }
        }
    }
    //Create an interface IDepartment with methods like AssignDepartment() and GetDepartmentDetails()
    interface IDepartment
    {
        void AssignDepartemnt(string departmentName);
        string GetDepartmentDetails();
    }
    //Create abstract class Employee
    abstract class Employee {
        public int employeeId;
        public string name;
        public double baseSalary;
        public string departmentName;

        public int EmployeeId { 
            get { return employeeId; }
            private set { employeeId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = string.IsNullOrWhiteSpace(value) ? "Unknown" : value; }
        }
        public double BaseSalary
        {
            get { return baseSalary; }
            protected set { baseSalary = value > 0 ? value : 0; }
        }
        public Employee(int employeeId, string name, double baseSalary)
        {
            this.employeeId = employeeId;
            this.name = name;
            this.baseSalary = baseSalary;
        }
        // Abstract method to be implemented in derived classes
        public abstract double CalculateSalary();
        // Method to display employee details
        public void DisplayDetails()
        {
            Console.WriteLine("\n==== Employee Details ====");
            Console.WriteLine($"Employee Name : {name}");
            Console.WriteLine($"Employee Id   : {employeeId}");
            Console.WriteLine($"Base Salary   : {baseSalary}");
            Console.WriteLine($"Calculated Salary : {CalculateSalary()}");
            Console.WriteLine($"Department    : {departmentName}");
        }
        // Methods to assign and get department details
        public void AssignDepartment(string departmentName)
        {
            this.departmentName = departmentName;
        }
        public string GetDepartmentDetails()
        {
            return departmentName;
        }
    }
    // Full-time employee class
    class FullTimeEmployee : Employee
    {
        private double bonus;
        public FullTimeEmployee(int employeeId, string name, double baseSalary, double bonus)
            : base(employeeId, name, baseSalary)
        {
            this.bonus = bonus;
        }
        public override double CalculateSalary()
        {
            return baseSalary + bonus;
        }
           
        }
        // Part-time employee class
        class PartTimeEmployee : Employee
        {
            private int hoursWorked;
            private double hourlyRate;

            public PartTimeEmployee(int employeeId, string name, int hoursWorked, double hourleRate)
                : base(employeeId, name, 0)
            {
                this.hoursWorked = hoursWorked;
                this.hourlyRate = hourleRate;
            }
            public override double CalculateSalary()
            {
                return hoursWorked * hourlyRate;
            }

        }
    }
}
