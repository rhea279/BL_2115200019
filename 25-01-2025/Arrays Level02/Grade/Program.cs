using System;

class StudentGrades
{
    static void Main()
    {
        // Take input for the number of students
        Console.Write("Enter the number of students: ");
        int numStudents = Convert.ToInt32(Console.ReadLine());

        // Arrays to store marks, percentages, and grades
        int[] physicsMarks = new int[numStudents];
        int[] chemistryMarks = new int[numStudents];
        int[] mathsMarks = new int[numStudents];
        double[] percentages = new double[numStudents];
        string[] grades = new string[numStudents];

        // Take input for marks and calculate percentage and grade for each student
        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"Enter details for student {i + 1}:");

            // Input marks for each subject
            physicsMarks[i] = GetValidMark("Physics");
            chemistryMarks[i] = GetValidMark("Chemistry");
            mathsMarks[i] = GetValidMark("Maths");

            // Calculate percentage
            double totalMarks = physicsMarks[i] + chemistryMarks[i] + mathsMarks[i];
            percentages[i] = (totalMarks / 300) * 100;

            // Assign grade based on percentage
            if (percentages[i] >= 80)
                grades[i] = "Level 4 , above agency-normalized standards";
            else if (percentages[i] >= 70)
                grades[i] = "Level 3 , at agency-normalized standards";
            else if (percentages[i] >= 60)
                grades[i] = "Level 2 , below, but approaching agency-normalized standards";
			else if (percentages[i] >= 50)
                grades[i] = "Level 1 , well below agency-normalized standards";
			else if (percentages[i] >= 40)
                grades[i] = "Level 1- ,too below agency-normalized standards";
            else
                grades[i] = "Remedial Standards";
        }

        // Display the marks, percentages, and grades of each student
        Console.WriteLine("\nStudent Results:");
        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"\nStudent {i + 1}:");
            Console.WriteLine($"Physics: {physicsMarks[i]}");
            Console.WriteLine($"Chemistry: {chemistryMarks[i]}");
            Console.WriteLine($"Maths: {mathsMarks[i]}");
            Console.WriteLine($"Percentage: {percentages[i]:F2}%");
            Console.WriteLine($"Grade: {grades[i]}");
        }
    }

    // Method to ensure valid positive marks input
    static int GetValidMark(string subject)
    {
        int mark;
        while (true)
        {
            Console.Write($"Enter marks for {subject}: ");
            mark = Convert.ToInt32(Console.ReadLine());

            // Ensure marks are between 0 and 100
            if (mark >= 0 && mark <= 100)
            {
                return mark;
            }
            else
            {
                Console.WriteLine("Invalid input! Marks should be between 0 and 100. Please enter again.");
            }
        }
    }
}
