using System;
using System.Collections.Generic;

namespace School_Students
{
    class Program
    {
        static void Main(string[] args)
        {
            School school = null;
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("School Management System");
                Console.WriteLine("1. Create School");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Display School Details");
                Console.WriteLine("6. View Student's Courses");
                Console.WriteLine("7. View Course's Enrolled Students");
                Console.WriteLine("8. Exit");
                Console.Write("Select an option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter School Name: ");
                        string schoolName = Console.ReadLine();
                        school = new School(schoolName);
                        Console.WriteLine("School created successfully!");
                        break;

                    case "2":
                        if (school == null)
                        {
                            Console.WriteLine("Create a school first.");
                            break;
                        }
                        Console.Write("Enter Student ID: ");
                        int studentID = int.Parse(Console.ReadLine());
                        Console.Write("Enter Student Name: ");
                        string studentName = Console.ReadLine();
                        school.AddStudent(studentID, studentName);
                        break;

                    case "3":
                        if (school == null)
                        {
                            Console.WriteLine("Create a school first.");
                            break;
                        }
                        Console.Write("Enter Course Name: ");
                        string courseName = Console.ReadLine();
                        school.AddCourse(courseName);
                        break;

                    case "4":
                        if (school == null)
                        {
                            Console.WriteLine("Create a school first.");
                            break;
                        }
                        Console.Write("Enter Student ID: ");
                        int studID = int.Parse(Console.ReadLine());
                        Student student = school.GetStudent(studID);
                        if (student == null)
                        {
                            Console.WriteLine("Student not found.");
                            break;
                        }
                        Console.Write("Enter Course Name: ");
                        string crsName = Console.ReadLine();
                        Course course = school.GetCourse(crsName);
                        if (course == null)
                        {
                            Console.WriteLine("Course not found.");
                            break;
                        }
                        course.EnrolledStudents(student);
                        break;

                    case "5":
                        if (school == null)
                        {
                            Console.WriteLine("No school exists.");
                            break;
                        }
                        school.DisplaySchoolDetails();
                        break;

                    case "6":
                        if (school == null)
                        {
                            Console.WriteLine("No school exists.");
                            break;
                        }
                        Console.Write("Enter Student ID: ");
                        int stID = int.Parse(Console.ReadLine());
                        Student stud = school.GetStudent(stID);
                        if (stud == null)
                        {
                            Console.WriteLine("Student not found.");
                            break;
                        }
                        stud.DisplayEnrolledCourses();
                        break;

                    case "7":
                        if (school == null)
                        {
                            Console.WriteLine("No school exists.");
                            break;
                        }
                        Console.Write("Enter Course Name: ");
                        string cName = Console.ReadLine();
                        Course crs = school.GetCourse(cName);
                        if (crs == null)
                        {
                            Console.WriteLine("Course not found.");
                            break;
                        }
                        crs.DisplayEnrolledStudents();
                        break;

                    case "8":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
        class School
        {
            public string SchoolName;
            private List<Student> students;
            private List<Course> courses;

            public School(string schoolName)
            {
                this.SchoolName = schoolName;
                students = new List<Student>();
                courses = new List<Course>();
            }
            public void AddStudent(int studentID, string name)
            {
                students.Add(new Student(studentID, name));
                Console.WriteLine("Student added successfully!");
            }

            public void AddCourse(string courseName)
            {
                courses.Add(new Course(courseName));
                Console.WriteLine("Course added successfully!");
            }

            public Student GetStudent(int studentID)
            {
                return students.Find(s => s.StudentId == studentID);
            }

            public Course GetCourse(string courseName)
            {
                return courses.Find(c => c.CourseName == courseName);
            }

            public void DisplaySchoolDetails()
            {
                Console.WriteLine($"\nSchool: {SchoolName}");

                Console.WriteLine("\nStudents:");
                if (students.Count == 0)
                    Console.WriteLine("  No students available.");
                else
                    foreach (var student in students)
                        Console.WriteLine($"  Student ID: {student.StudentId}, Name: {student.Name}");

                Console.WriteLine("\nCourses:");
                if (courses.Count == 0)
                    Console.WriteLine("  No courses available.");
                else
                    foreach (var course in courses)
                        Console.WriteLine($"  Course: {course.CourseName}");
            }
        }
        class Student
        {
            public string Name;
            public int StudentId;
            private List<Course> enrolledCourses;

            public Student(int studentId, string name)
            {
                this.StudentId = studentId;
                this.Name = name;
                enrolledCourses = new List<Course>();
            }

            public void AddCourse(Course course)
            {
                if (!enrolledCourses.Contains(course))
                {
                    enrolledCourses.Add(course);
                }
            }

            public void DisplayEnrolledCourses()
            {
                Console.WriteLine($"\nStudent{Name} (ID :{StudentId})");
                if (enrolledCourses.Count == 0)
                {
                    Console.WriteLine("No courses enrolled");
                }
                else
                {
                    foreach (Course course in enrolledCourses)
                    {
                        Console.WriteLine($"Course:{course.CourseName}");
                    }
                }


            }
        }
        class Course
        {
            public string CourseName;
            private List<Student> enrolledStudents;

            public Course(string courseName)
            {
                this.CourseName = courseName;
                enrolledStudents = new List<Student>();
            }

            public void EnrolledStudents(Student student)
            {
                if (!enrolledStudents.Contains(student))
                {
                    enrolledStudents.Add(student);
                    student.AddCourse(this);
                    Console.WriteLine($"{student.Name} Enrolled in {CourseName}");

                }
                else
                {
                    Console.WriteLine("Student is already enrolled");
                }
            }
            public void DisplayEnrolledStudents()
            {
                Console.WriteLine($"\nCourse: {CourseName}");
                if (enrolledStudents.Count == 0)
                {
                    Console.WriteLine("  No students enrolled.");
                }
                else
                {
                    foreach (var student in enrolledStudents)
                    {
                        Console.WriteLine($"  Student ID: {student.StudentId}, Name: {student.Name}");
                    }
                }
            }
        }

    }
}
