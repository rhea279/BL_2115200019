using System;
using System.Collections.Generic;
namespace University_Faculties_Departments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            University university = new University("GLA University");
            List<Faculty> independentFaculties = new List<Faculty>();

            while (true) {
                Console.WriteLine($"Welcome to {university.Name} ");
                Console.WriteLine("1. Add a Department to University");
                Console.WriteLine("2. Add a Faculty Member to University");
                Console.WriteLine("3. Add an Independent Faculty Member (Not in University)");
                Console.WriteLine("4. Display University Details");
                Console.WriteLine("5. Delete University");
                Console.WriteLine("6. Show Independent Faculty Members");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Choose an option");

                int choice;
                while(!int.TryParse(Console.ReadLine(), out choice) || choice >7 || choice < 0)
                {
                    Console.WriteLine("Invalid Choice");
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Department Name:");
                        string deptName = Console.ReadLine();
                        university.AddDepartment(deptName);
                        Console.WriteLine($"Department {deptName} Successfully Added");
                        break;
                    case 2:
                        Console.WriteLine("Enter Faculty Name: ");
                        string facultyName = Console.ReadLine();
                        Console.WriteLine("Enter Faculty Specialization: ");
                        string specialization = Console.ReadLine();
                        university.AddFaculty(new Faculty(facultyName, specialization));
                        Console.WriteLine($"Faculty {facultyName} Successfully Added");
                        break;
                    case 3:
                        Console.WriteLine("Enter Faculty Name: ");
                        string Name = Console.ReadLine();
                        Console.WriteLine("Enter Faculty Specialization: ");
                        string specializationName = Console.ReadLine();
                        independentFaculties.Add(new Faculty(Name, specializationName));
                        Console.WriteLine($"Faculty {Name} Successfully Added");
                        break;
                    case 4:
                        university.DisplayUniversityDetails();
                        break;
                    case 5:
                        Console.WriteLine($"Deleting University '{university.Name}'... All Departments Deleted");
                        university = null;
                        Console.WriteLine("University Deleted");
                        break;
                    case 6:
                        if(independentFaculties.Count == 0)
                        {
                            Console.WriteLine("\nNo Independengt Faculty Member Found");
                            break;
                        }
                        Console.WriteLine("\n Independent Faculty Members :");
                        foreach(var faculty in independentFaculties)
                        {
                            Console.WriteLine($"{faculty.Name} (Specialization: {faculty.Specialization})");
                        }
                        break;
                        case 7:
                        Console.WriteLine("Exiting Application");
                        return;
                }
            }
        }
    }
    class University {
        public string Name;
        private List<Department> Departments;
        private List<Faculty> Faculties;

        public University(string name) {
            this.Name = name;
            Departments = new List<Department>();
            Faculties = new List<Faculty>();
        }

        public void AddDepartment(string departmentName) {
            Departments.Add(new Department(departmentName));
        }

        public void AddFaculty(Faculty faculty) {
            Faculties.Add(faculty);
        }

        public void DisplayUniversityDetails() {
            Console.WriteLine($"\nUniversity : {Name}");
            Console.WriteLine("Departments: ");
            if (Departments.Count == 0)
                Console.WriteLine("No Departments Yet.");
            foreach(Department dept in Departments)
            {
                Console.WriteLine($" -{dept.Name}");
            }
            Console.WriteLine("Faculty Members:");
            if (Faculties.Count == 0) Console.WriteLine("No Faculty Members Yet");
            foreach(Faculty faculty in Faculties)
            {
                Console.WriteLine($" - {faculty.Name} (Specialization :{faculty.Specialization})");
            }
        }
    }
    class Faculty {
        public string Name;
        public string Specialization;

        public Faculty(string name, string specialization) {
            this.Name=name;
            this.Specialization=specialization;
        }
    }
    class Department { 
        public string Name;
        private List <Faculty> Faculty;
        private List<Department> Departments;

        public Department(string name) {
            this.Name = name;
            Faculty = new List<Faculty>();
        }

        public void AddDepartment(Department deptName)
        {
            Departments.Add(deptName);
        }
        public void AddFaculty(Faculty f) {
            Faculty.Add(f);
        }

        public void DisplayDepartmentDetails(Department department) {
            Console.WriteLine($"\nDepartment : {Name}");
            Console.WriteLine("Faculty Members :");
            if (Faculty.Count == 0) Console.WriteLine("No Faculty Member Yet.");
            foreach(Faculty f in Faculty)
            {
                Console.WriteLine($" - {f.Name} (Specialization: {f.Specialization})");
            }
        }
    }

}
