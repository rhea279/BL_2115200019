using System;
using System.Collections.Generic;

namespace UniversityManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating Professors
            Professor prof1 = new Professor("Dr. Smith");
            Professor prof2 = new Professor("Dr. Johnson");

            // Creating Students
            Student student1 = new Student("Alice");
            Student student2 = new Student("Bob");

            // Creating Courses
            Course course1 = new Course("Computer Science");
            Course course2 = new Course("Mathematics");

            // Assigning Professors to Courses (Aggregation)
            course1.AssignProfessor(prof1);
            course2.AssignProfessor(prof2);

            // Students Enrolling in Courses (Association)
            student1.EnrollCourse(course1);
            student2.EnrollCourse(course2);
            student1.EnrollCourse(course2); // Alice enrolls in Mathematics too

            // Display Course Details
            course1.DisplayCourseDetails();
            course2.DisplayCourseDetails();

            // Display Student Details
            student1.DisplayStudentDetails();
            student2.DisplayStudentDetails();
        }
    }

    class Student
    {
        public string Name { get; }
        private List<Course> enrolledCourses;

        public Student(string name)
        {
            Name = name;
            enrolledCourses = new List<Course>();
        }

        public void EnrollCourse(Course course)
        {
            enrolledCourses.Add(course);
            course.AddStudent(this);  // Establishing Association
            Console.WriteLine($"{Name} enrolled in {course.CourseName}.");
        }

        public void DisplayStudentDetails()
        {
            Console.WriteLine($"\nStudent: {Name}");
            Console.WriteLine("Enrolled Courses:");
            foreach (var course in enrolledCourses)
            {
                Console.WriteLine($"- {course.CourseName}");
            }
        }
    }

    class Professor
    {
        public string Name { get; }

        public Professor(string name)
        {
            Name = name;
        }

        public void DisplayProfessorDetails()
        {
            Console.WriteLine($"Professor: {Name}");
        }
    }

    class Course
    {
        public string CourseName { get; }
        private Professor AssignedProfessor;
        private List<Student> enrolledStudents;

        public Course(string name)
        {
            CourseName = name;
            enrolledStudents = new List<Student>();
        }

        public void AssignProfessor(Professor professor)
        {
            AssignedProfessor = professor;  // Aggregation (Professor can exist independently)
            Console.WriteLine($"{professor.Name} assigned to {CourseName}.");
        }

        public void AddStudent(Student student)
        {
            enrolledStudents.Add(student);  // Association (Student enrolls in the course)
        }

        public void DisplayCourseDetails()
        {
            Console.WriteLine($"\nCourse: {CourseName}");
            Console.WriteLine($"Professor: {(AssignedProfessor != null ? AssignedProfessor.Name : "None")}");
            Console.WriteLine("Enrolled Students:");
            foreach (var student in enrolledStudents)
            {
                Console.WriteLine($"- {student.Name}");
            }
        }
    }
}
