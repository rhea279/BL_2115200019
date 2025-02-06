using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Xml.Serialization;
namespace Company_Departments
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = null;

            while (true) {
                Console.WriteLine("\n1. Create Company");
                Console.WriteLine("2. Add Department");
                Console.WriteLine("3. Add Employee to Department");
                Console.WriteLine("4. Display Company Details");
                Console.WriteLine("5. Delete Company");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Choose an option: ");

                int option;
                while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 6) {
                    Console.WriteLine("Invalid Option!");
                    return;
                }

                switch (option)
                {
                    case 1:
                        Console.Write("Enter Company Name: ");
                        string companyName = Console.ReadLine();
                        company = new Company(companyName);
                        Console.WriteLine("Company created successfully!");
                        break;
                    case 2:
                        if (company == null)
                        {
                            Console.WriteLine("Create a company first.");
                            break;
                        }
                        Console.Write("Enter Department Name: ");
                        string departmentName = Console.ReadLine();
                        company.AddDepartment(departmentName);
                        break;

                    case 3:
                        if (company == null)
                        {
                            Console.WriteLine("Create a company first.");
                            break;
                        }
                        Console.Write("Enter Department Name: ");
                        string deptName = Console.ReadLine();
                        Console.Write("Enter Employee ID: ");
                        int employeeID = int.Parse(Console.ReadLine());
                        Console.Write("Enter Employee Name: ");
                        string empName = Console.ReadLine();
                        Console.Write("Enter Employee Designation: ");
                        string designation = Console.ReadLine();
                        company.AddEmployeeToDepartment(deptName, employeeID, empName, designation);
                        break;

                    case 4:
                        if (company == null)
                        {
                            Console.WriteLine("No company exists.");
                            break;
                        }
                        company.DisplayCompany();
                        break;

                    case 5:
                        if (company == null)
                        {
                            Console.WriteLine("No company exists.");
                            break;
                        }
                        company.DeleteCompany();
                        company = null;
                        break;

                    case 6:
                        Console.WriteLine("Thank You for Using Our Application");
                        return;

                }

            }
        }
    }

    class Company {
        public string Name;
        List<Department> departments;

        public Company(string name) {
            this.Name = name;
            this.departments= new List<Department>();
        }

        public void AddDepartment(string departmentName) {
            departments.Add(new Department(departmentName));
            Console.WriteLine("New Department Added Successfully!");
        }
        public void AddEmployeeToDepartment(string departmentName, int employeeID, string name, string designation)
        {
            foreach (var dept in departments)
            {
                if (dept.DepartmentName == departmentName)
                {
                    dept.AddEmployee( name, employeeID, designation);
                    return;
                }
            }
            Console.WriteLine("Department not found.");
        }

        public void DisplayCompany()
        {
            Console.WriteLine($"\nCompany: {Name}");
            if (departments.Count == 0)
            {
                Console.WriteLine("No departments found.");
            }
            else
            {
                foreach (var dept in departments)
                {
                    dept.DisplayDepartment();
                }
            }
        }

        public void DeleteCompany()
        {
            foreach (var dept in departments)
            {
                dept.RemoveAllEmployees();
            }
            departments.Clear();
            Console.WriteLine("Company and all associated departments and employees deleted.");
        }

    }
    class Department {
        public string DepartmentName;
        private List<Employee> employees;

        public Department(string departmentName) { 
            this.DepartmentName = departmentName;
            this.employees = new List<Employee>();
        }

        public void AddEmployee( string name, int employeeId, string designation) {
            employees.Add(new Employee( name, employeeId, designation));
            Console.WriteLine("Employee Added Successfully!");
        }

        public void DisplayDepartment()
        {
            Console.WriteLine($"\nDepartment: {DepartmentName}");
            if (employees.Count == 0)
            {
                Console.WriteLine("  No employees in this department.");
            }
            else
            {
                foreach (var emp in employees)
                {
                    emp.DisplayEmployee();
                }
            }
        }

        public void RemoveAllEmployees()
        {
            employees.Clear();
        }

    }

    class Employee {
        public string Name;
        public int EmployeeId;
        public string Designation;

        public Employee(string name, int employeeId, string designation ) {
            this.Name = name;
            this.EmployeeId = employeeId;
            this.Designation = designation;
        }

        public void DisplayEmployee() {
            Console.WriteLine($"Employee Id: {EmployeeId} \n Employee Name: {Name} \nDesignation: {Designation}");
        }
    }

}
