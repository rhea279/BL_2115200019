using System;

class Grade2
{
    static void Main()
    {
        // Take input for the number of students
        Console.Write("Enter the number of students: ");
        int numberOfStudents = Convert.ToInt32(Console.ReadLine());

        // Create a 2D array to store the marks of each student in 3 subjects (Physics, Chemistry, Maths)
        int[,] marks = new int[numberOfStudents, 3];  // [students, subjects]
        double[] percentages = new double[numberOfStudents];  // Store the percentage of each student
        string[] grades = new string[numberOfStudents];  // Store the grade of each student

        // Take input for marks of students in physics, chemistry, and maths
        for (int i = 0; i < numberOfStudents; i++)
        {
            Console.WriteLine($"Enter marks for student {i + 1}:");

            // Get marks for Physics
            marks[i, 0] = GetValidMark("Physics");

            // Get marks for Chemistry
            marks[i, 1] = GetValidMark("Chemistry");

            // Get marks for Maths
            marks[i, 2] = GetValidMark("Maths");

            // Calculate percentage for the student
            percentages[i] = CalculatePercentage(marks[i, 0], marks[i, 1], marks[i, 2]);

            // Assign grade based on percentage
            grades[i] = GetGrade(percentages[i]);
        }

        // Display the marks, percentage, and grade for each student
        Console.WriteLine("\nStudent Results:");
        for (int i = 0; i < numberOfStudents; i++)
        {
            Console.WriteLine($"\nStudent {i + 1}:");
            Console.WriteLine($"Physics: {marks[i, 0]}");
            Console.WriteLine($"Chemistry: {marks[i, 1]}");
            Console.WriteLine($"Maths: {marks[i, 2]}");
            Console.WriteLine($"Percentage: {percentages[i]:F2}%");
            Console.WriteLine($"Grade: {grades[i]}");
        }
    }

    // Method to get valid marks (between 0 and 100)
    static int GetValidMark(string subject)
    {
        int mark;
        while (true)
        {
            Console.Write($"Enter marks for {subject}: ");
            mark = Convert.ToInt32(Console.ReadLine());

            // Ensure the marks are between 0 and 100
            if (mark >= 0 && mark <= 100)
            {
                return mark;
            }
            else
            {
                Console.WriteLine("Invalid marks. Please enter marks between 0 and 100.");
            }
        }
    }

    // Method to calculate the percentage based on marks in 3 subjects
    static double CalculatePercentage(int physicsMarks, int chemistryMarks, int mathsMarks)
    {
        double totalMarks = physicsMarks + chemistryMarks + mathsMarks;
        return (totalMarks / 300) * 100;  // Total marks are 300 (100 per subject)
    }

    // Method to determine the grade based on percentage
    static string GetGrade(double percentage)
    {
        if (percentage >= 80)
            return "Level 4 , above agency-normalized standards";
        else if (percentage >= 70)
            return "Level 3 , at agency-normalized standards";
        else if (percentage >= 60)
            return "Level 2 , below, but approaching agency-normalized standards";
        else if (percentage >= 50)
            return "Level 1 , well below agency-normalized standards";
        else if (percentage >= 40)
            return "Level 1- , too below agency-normalized standards";
        else
            return "Remedial Standards";
    }
}
