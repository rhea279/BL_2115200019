using System;

class Student
{
    public int RollNumber { get; set; }
    protected string Name { get; set; }
    private double CGPA;

    public Student(int rollNumber, string name, double cgpa)
    {
        RollNumber = rollNumber;
        Name = name;
        CGPA = cgpa;
    }

    public void SetCGPA(double cgpa)
    {
        CGPA = cgpa;
    }

    public double GetCGPA()
    {
        return CGPA;
    }
}

class PostgraduateStudent : Student
{
    public PostgraduateStudent(int rollNumber, string name, double cgpa) : base(rollNumber, name, cgpa) {}

    public void DisplayDetails()
    {
        Console.WriteLine($"Postgraduate Student - Roll Number: {RollNumber}, Name: {Name}, CGPA: {GetCGPA()}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Roll Number: ");
        int rollNumber = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter CGPA: ");
        double cgpa = Convert.ToDouble(Console.ReadLine());

        PostgraduateStudent student = new PostgraduateStudent(rollNumber, name, cgpa);
        student.DisplayDetails();
    }
}
