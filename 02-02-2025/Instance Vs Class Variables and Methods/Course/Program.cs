using System;
class Course
{
    public string CourseName { get; set; }
    public int Duration { get; set; } // in weeks
    public double Fee { get; set; }
    private static string instituteName = "Default Institute";

    public Course(string courseName, int duration, double fee)
    {
        CourseName = courseName;
        Duration = duration;
        Fee = fee;
    }

    public void DisplayCourseDetails()
    {
        Console.WriteLine($"Course: {CourseName}, Duration: {Duration} weeks, Fee: {Fee}, Institute: {instituteName}");
    }

    public static void UpdateInstituteName(string newName)
    {
        instituteName = newName;
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Enter Institute Name: ");
        string instituteName = Console.ReadLine();
        Course.UpdateInstituteName(instituteName);
        Console.Write("Enter Course Name: ");
        string courseName = Console.ReadLine();
        Console.Write("Enter Course Duration (weeks): ");
        int courseDuration = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Course Fee: ");
        double courseFee = Convert.ToDouble(Console.ReadLine());
        Course course = new Course(courseName, courseDuration, courseFee);
        course.DisplayCourseDetails();
	}
}