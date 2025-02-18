using System;
using System.Collections.Generic;

// Abstract base class for course types
public abstract class CourseType
{
    public string CourseName { get; set; }
    public int CreditHours { get; set; }

    public CourseType(string courseName, int creditHours)
    {
        CourseName = courseName;
        CreditHours = creditHours;
    }

    public abstract void DisplayCourseDetails(); // Abstract method to display course details
}

// Exam-based course
public class ExamCourse : CourseType
{
    public int ExamDuration { get; set; } // Duration of the exam in minutes

    public ExamCourse(string courseName, int creditHours, int examDuration)
        : base(courseName, creditHours)
    {
        ExamDuration = examDuration;
    }

    public override void DisplayCourseDetails()
    {
        Console.WriteLine($"Course: {CourseName} (Exam-based)\nCredit Hours: {CreditHours}\nExam Duration: {ExamDuration} minutes\n");
    }
}

// Assignment-based course
public class AssignmentCourse : CourseType
{
    public int AssignmentCount { get; set; } // Number of assignments

    public AssignmentCourse(string courseName, int creditHours, int assignmentCount)
        : base(courseName, creditHours)
    {
        AssignmentCount = assignmentCount;
    }

    public override void DisplayCourseDetails()
    {
        Console.WriteLine($"Course: {CourseName} (Assignment-based)\nCredit Hours: {CreditHours}\nNumber of Assignments: {AssignmentCount}\n");
    }
}

// Generic Course class
public class Course<T> where T : CourseType
{
    public T CourseDetails { get; set; } // Property to hold the specific course details

    public Course(T courseDetails)
    {
        CourseDetails = courseDetails;
    }

    public void DisplayCourseInfo()
    {
        CourseDetails.DisplayCourseDetails(); // Call the method to display course details
    }
}

// University Course Management System
public class University
{
    private List<CourseType> courses = new List<CourseType>(); // List to hold courses of different types

    // Method to add a course to the system
    public void AddCourse<T>(T course) where T : CourseType
    {
        courses.Add(course);
    }

    // Method to display all courses
    public void DisplayCourses()
    {
        Console.Clear();
        Console.WriteLine("===== List of Courses =====");
        if (courses.Count == 0)
        {
            Console.WriteLine("No courses available.\n");
        }
        else
        {
            foreach (var course in courses)
            {
                course.DisplayCourseDetails();
            }
        }
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }
}

public class Program
{
    public static void Main()
    {
        var university = new University();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("===== University Course Management System =====");
            Console.WriteLine("1. Add a Course");
            Console.WriteLine("2. Display Courses");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddCourseMenu(university);
                    break;
                case "2":
                    university.DisplayCourses();
                    break;
                case "3":
                    exit = true;
                    Console.WriteLine("Exiting the program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void AddCourseMenu(University university)
    {
        Console.Clear();
        Console.WriteLine("===== Add a Course =====");
        Console.Write("Enter Course Name: ");
        string courseName = Console.ReadLine();

        Console.Write("Enter Credit Hours: ");
        if (!int.TryParse(Console.ReadLine(), out int creditHours))
        {
            Console.WriteLine("Invalid input. Credit hours must be a number.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Select Course Type:");
        Console.WriteLine("1. Exam Course");
        Console.WriteLine("2. Assignment Course");
        Console.Write("Enter your choice: ");
        string typeChoice = Console.ReadLine();

        if (typeChoice == "1")
        {
            Console.Write("Enter Exam Duration (minutes): ");
            if (!int.TryParse(Console.ReadLine(), out int examDuration))
            {
                Console.WriteLine("Invalid input. Exam duration must be a number.");
                Console.ReadLine();
                return;
            }

            var examCourse = new ExamCourse(courseName, creditHours, examDuration);
            university.AddCourse(examCourse);
            Console.WriteLine("Exam Course added successfully.");
        }
        else if (typeChoice == "2")
        {
            Console.Write("Enter Number of Assignments: ");
            if (!int.TryParse(Console.ReadLine(), out int assignmentCount))
            {
                Console.WriteLine("Invalid input. Assignment count must be a number.");
                Console.ReadLine();
                return;
            }

            var assignmentCourse = new AssignmentCourse(courseName, creditHours, assignmentCount);
            university.AddCourse(assignmentCourse);
            Console.WriteLine("Assignment Course added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid course type selection.");
        }

        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine();
    }
}
