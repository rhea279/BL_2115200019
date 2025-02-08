using System;
namespace Employee_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee manager = new Manager("Alice", 101, 80000, 5);
            Employee developer = new Developer("Bob", 102, 60000, "C#");
            Employee intern = new Intern("Charlie", 103, 20000, "3 months");

            
            manager.DisplayDetails();
            Console.WriteLine();
            developer.DisplayDetails();
            Console.WriteLine();
            intern.DisplayDetails();
        }
    }
    //Define a base class Employee
    class Employee
    {
        //Add three attributes: Name (string), Id (integer), and Salary (double)
        public string Name { get; set; }
        public int Id { get; set; }
        public double Salary { get; set; }
        public Employee(string name, int id, double salary)
        {
            Name = name;
            Id = id;
            Salary = salary;
        }
        //Add a method DisplayDetails() to display the details of an employee.
        public virtual void DisplayDetails()
        {
            Console.WriteLine("Employee Details :");
            Console.WriteLine($"Name        : {Name}");
            Console.WriteLine($"Employee Id : {Id}");
            Console.WriteLine($"Salary      : {Salary}");
        }
    }
    //Define subclasses Manager
    class Manager : Employee { 
        public int TeamSize {  get; set; }
        public Manager(string name, int id, double salary,int teamSize)
            : base(name, id, salary)
        {
            TeamSize = teamSize;
        }
        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Team Size   : {TeamSize}");
        }
    }
    //Define subclasses Developer
    class Developer : Employee
    {
        public string ProgrammingLanguage { get; set; }
        public Developer(string name, int id, double salary,string proLang)
            : base(name, id, salary)
        {
            ProgrammingLanguage = proLang;
        }
        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Programming Language: {ProgrammingLanguage}");
        }
    }
    //Define subclasses Intern
    class Intern : Employee
    {
        public string InternshipDuration { get; set; }
        public Intern(string name, int id, double salary, string intDuration)
            : base(name, id, salary)
        {
            InternshipDuration = intDuration;
        }
        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Internship Duration : {InternshipDuration}");
        }
    }
}
