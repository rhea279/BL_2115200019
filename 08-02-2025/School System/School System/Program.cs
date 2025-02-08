using System;

namespace SchoolSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt user for role details
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Role (Teacher/Student/Staff): ");
            string role = Console.ReadLine().ToLower();

            Person person;

            if (role == "teacher")
            {
                Console.Write("Enter Subject: ");
                string subject = Console.ReadLine();
                person = new Teacher(name, age, subject);
            }
            else if (role == "student")
            {
                Console.Write("Enter Grade: ");
                string grade = Console.ReadLine();
                person = new Student(name, age, grade);
            }
            else if (role == "staff")
            {
                Console.Write("Enter Department: ");
                string department = Console.ReadLine();
                person = new Staff(name, age, department);
            }
            else
            {
                Console.WriteLine("Invalid role!");
                return;
            }

            Console.WriteLine("\nPerson Information:");
            person.DisplayRole();
        }
    }

    // Base class representing a person
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void DisplayRole()
        {
            Console.WriteLine("General Person");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
        }
    }

    // Teacher subclass
    class Teacher : Person
    {
        public string Subject { get; set; }

        public Teacher(string name, int age, string subject)
            : base(name, age)
        {
            Subject = subject;
        }

        public override void DisplayRole()
        {
            base.DisplayRole();
            Console.WriteLine("Role: Teacher");
            Console.WriteLine($"Subject: {Subject}");
        }
    }

    // Student subclass
    class Student : Person
    {
        public string Grade { get; set; }

        public Student(string name, int age, string grade)
            : base(name, age)
        {
            Grade = grade;
        }

        public override void DisplayRole()
        {
            base.DisplayRole();
            Console.WriteLine("Role: Student");
            Console.WriteLine($"Grade: {Grade}");
        }
    }

    // Staff subclass
    class Staff : Person
    {
        public string Department { get; set; }

        public Staff(string name, int age, string department)
            : base(name, age)
        {
            Department = department;
        }

        public override void DisplayRole()
        {
            base.DisplayRole();
            Console.WriteLine("Role: Staff");
            Console.WriteLine($"Department: {Department}");
        }
    }
}