using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Services;
namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Student.universityName = "GLA University";
            List<Student> students = new List<Student>();

            while (true) {
                Console.WriteLine("\n ==== Student Management System ====");
                Console.WriteLine("1. Enroll New Student");
                Console.WriteLine("2. Display Student Details");
                Console.WriteLine("3. Update Student Details");
                Console.WriteLine("4. Show Total Students");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an option : ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid Option! Enter a valid option (1 - 5):");
                }

                switch (choice) {
                    case 1:
                        Console.WriteLine("Enter Student Details");
                        Console.WriteLine("Enter Student's Full Name :");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter Roll Number :");
                        int rollNumber;
                        while (!int.TryParse(Console.ReadLine(), out rollNumber) || rollNumber <= 0) {
                            Console.WriteLine("Invalid Roll Number! Enter a Valid Roll Number :");
                        }

                        Console.Write("Enter Grade: ");
                        string grade = Console.ReadLine();

                        students.Add(new Student(name, rollNumber, grade));
                        Console.WriteLine("\nStudent Enrolled Successfully!");

                        break;
                    case 2:
                        Console.WriteLine("Enter Roll Number to View Details :");
                        int searchRoll;
                        while (!int.TryParse(Console.ReadLine(), out searchRoll)) {
                            Console.WriteLine("Enter a Valid Roll Number!");
                        }
                        Student student = students.Find(s => s.rollNumber == searchRoll);
                        if (student != null)
                        {
                            student.DisplayStudentDetails();
                        }
                        else {
                            Console.WriteLine("Student Not Found");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter Roll Number to Update Grade :");
                        int updateRoll;
                        while (!int.TryParse(Console.ReadLine(), out updateRoll))
                        {
                            Console.WriteLine("Enter a Valid Roll Number!");
                        }
                        Student foundStudent = students.Find(s => s.rollNumber == updateRoll);
                        if (foundStudent != null)
                        {
                            Console.Write("Enter New Grade : ");
                            string newGrade = Console.ReadLine();
                            foundStudent.UpdateGrade(newGrade);
                        }
                        else
                        {
                            Console.WriteLine("Student Not Found");
                        }
                        break;
                    case 4:
                        Student.DisplayTotalStudents();
                        break;
                    case 5:
                        Console.WriteLine("\nThank you for using University Student Management System!");
                        return;

                }


            }
        }
    }
    class Student {
        public static string universityName;
        public string name;
        public readonly int rollNumber;
        public string grade;
        private static int totalStudents = 0;

        public Student(string Name, int RollNumber, string Grade) {
            this.name = Name;
            this.rollNumber = RollNumber;
            this.grade = Grade;
            totalStudents++;
        }
        public void DisplayStudentDetails() {
            if (this is Student)
            {
                Console.WriteLine("\n----- Student Details -----");
                Console.WriteLine($"Student Name : {name}");
                Console.WriteLine($"Roll Number : {rollNumber}");
                Console.WriteLine($"Grade : {grade}");
                Console.WriteLine("---------------------------");
            }
        }
        public void UpdateGrade(string newGrade) {
            if (this is Student)
            {
                grade = newGrade;
                Console.WriteLine("Grade Updated!");
            }
        }
        public static void DisplayTotalStudents() {
            
                Console.WriteLine($"Total Number of Students : {totalStudents}");
            
        }
    }
}
