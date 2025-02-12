using System;
using System.Collections.Generic;

namespace Student_Record_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentRecord studentRecord = new StudentRecord();
            while (true)
            {
                Console.WriteLine("\n==== Student Record Management ====");
                Console.WriteLine("1. Add a new student record at the beginning, end, or at a specific position ");
                Console.WriteLine("2. Delete a student record by Roll Number.");
                Console.WriteLine("3. Search for a student record by Roll Number.");
                Console.WriteLine("4. Display all student records.");
                Console.WriteLine("5. Update a student's grade based on their Roll Number.");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Choose an option:");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nChoose option where you want to add student record :\n1. At Beginning \n2. At the end. \n3. At a Specific Position.\nEnter your choice:");
                        int choice = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Student Name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter Student Roll Number:");
                        int rollNo = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Student Grade:");
                        char grade = char.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                studentRecord.AddStudentFirst(name, rollNo, grade);
                                break;
                            case 2:
                                studentRecord.AddStudentLast(name, rollNo, grade);
                                break;
                            case 3:
                                Console.WriteLine("Enter position where you want to add student:");
                                int position = int.Parse(Console.ReadLine());
                                studentRecord.AddStudentAtPosition(name, rollNo, grade, position);
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nEnter Student Roll Number you want to delete:");
                        int rollNumber = int.Parse(Console.ReadLine());
                        studentRecord.DeleteRollNumber(rollNumber);
                        break;
                    case 3:
                        Console.WriteLine("\nEnter Student Roll Number you want to search:");
                        int rollNumber1 = int.Parse(Console.ReadLine());
                        studentRecord.SearchRollNumber(rollNumber1);
                        break;
                    case 4:
                        Console.WriteLine("\n==== Student Record ====");
                        studentRecord.DisplayStudentRecord();
                        break;
                    case 5:
                        Console.WriteLine("\nEnter Student Roll Number you want to update:");
                        int rollNumber2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Updated Grade:");
                        char updatedGrade = char.Parse(Console.ReadLine());
                        studentRecord.UpdateStudentGrade(rollNumber2, updatedGrade);
                        break;
                    case 6:
                        Console.WriteLine("\nClosing System.");
                        return;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            }
        }
        class Student
        {
            public string Name;
            public int RollNo;
            public char Grade;
            public Student Next;

            public Student(string name, int rollNo, char grade)
            {
                Name = name;
                RollNo = rollNo;
                Grade = grade;
                Next = null;
            }
        }
        class StudentRecord
        {
            public Student head;

            //Add a new student record at the beginning
            public void AddStudentFirst(string name, int rollNo, char grade)
            {
                Student newStudent = new Student(name, rollNo, grade);
                newStudent.Next = head;
                head = newStudent;
            }
            //Add a new student record at the end
            public void AddStudentLast(string name, int rollNo, char grade)
            {
                Student newStudent = new Student(name, rollNo, grade);
                if (head == null)
                {
                    head = newStudent;
                }
                Student temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newStudent;
            }
            //Add a new student record at a specific position.
            public void AddStudentAtPosition(string name, int rollNo, char grade, int position)
            {
                Student newStudent = new Student(name, rollNo, grade);
                if (position < 1)
                {
                    Console.WriteLine("Invalid Position Entered");
                    return;
                }
                if (position == 1)
                {
                    newStudent.Next = head;
                    head = newStudent;
                    return;
                }
                Student temp = head;
                for (int i = 1; temp != null && i < position - 1; i++)
                {
                    temp = temp.Next;
                }
                if (temp == null)
                {
                    Console.WriteLine("Position out of range.");
                    return;
                }
                newStudent.Next = temp.Next;
                temp.Next = newStudent;
            }
            //Delete a student record by Roll Number
            public void DeleteRollNumber(int rollNo)
            {
                if (head == null)
                {
                    Console.WriteLine("List is Empty");
                    return;
                }
                if (head.RollNo == rollNo)
                {
                    head = head.Next;
                    Console.WriteLine($"Student with Roll Number {rollNo} deleted.");
                    return;
                }
                Student current = head;
                Student previous = null;
                while (current != null && current.RollNo != rollNo)
                {
                    previous = current;
                    current = current.Next;
                }
                if (current == null)
                {
                    Console.WriteLine("Roll Number not found in the list");
                    return;
                }
                previous.Next = current.Next;
                Console.WriteLine($"Student with Roll Number {rollNo} deleted.");
            }
            //Search for a student record by Roll Number.
            public void SearchRollNumber(int rollNo)
            {
                if (head == null)
                {
                    Console.WriteLine("List is empty.");
                    return;
                }
                Student temp = head;
                while (temp != null)
                {
                    if (temp.RollNo == rollNo)
                    {
                        Console.WriteLine($"Student Found:\n Student Name : {temp.Name}\n Roll Number : {temp.RollNo}\nGrade : {temp.Grade}");
                        return;
                    }
                    temp = temp.Next;
                }
                Console.WriteLine("Student not found");
            }
            //Search for a student record by Roll Number.
            public void DisplayStudentRecord()
            {
                if (head == null)
                {
                    Console.WriteLine("No Student Record Found");
                    return;
                }
                Student temp = head;
                while (temp != null)
                {
                    Console.WriteLine($"Roll Number : {temp.RollNo} \nStudent Name : {temp.Name} \nGrade : {temp.Grade}");
                    temp = temp.Next;
                }
            }
            //Update a student's grade based on their Roll Number.
            public void UpdateStudentGrade(int rollNo, char grade)
            {
                if (head == null)
                {
                    Console.WriteLine("No Student Record Found");
                    return;
                }
                Student temp = head;
                while (temp != null)
                {
                    if (temp.RollNo == rollNo)
                    {
                        temp.Grade = grade;
                        Console.WriteLine("Grade Updated");
                        return;
                    }
                    temp = temp.Next;
                }
                Console.WriteLine("Roll Number Not Found");
            }

        }
    }
}
