using System;
using System.Collections.Generic;

// Abstract class for Job Roles
public abstract class JobRole
{
    public string RoleName { get; }

    protected JobRole(string roleName)
    {
        RoleName = roleName;
    }

    public abstract void DisplayCriteria();  // Method to display screening criteria
}

// Software Engineer Role
public class SoftwareEngineer : JobRole
{
    public SoftwareEngineer() : base("Software Engineer") { }

    public override void DisplayCriteria()
    {
        Console.WriteLine("🔹Required: Strong coding skills, knowledge of algorithms & data structures, experience with cloud platforms.");
    }
}

// Data Scientist Role
public class DataScientist : JobRole
{
    public DataScientist() : base("Data Scientist") { }

    public override void DisplayCriteria()
    {
        Console.WriteLine("Required: Strong statistics background, machine learning experience, Python/R proficiency.");
    }
}

// Generic Resume Class
public class Resume<T> where T : JobRole
{
    public string CandidateName { get; }
    public string Skills { get; }
    public T JobRole { get; }

    public Resume(string candidateName, string skills, T jobRole)
    {
        CandidateName = candidateName;
        Skills = skills;
        JobRole = jobRole;
    }

    public void DisplayResume()
    {
        Console.WriteLine($"\nResume - {CandidateName}");
        Console.WriteLine($"Applying for: {JobRole.RoleName}");
        Console.WriteLine($"Skills: {Skills}");
        JobRole.DisplayCriteria();
        Console.WriteLine("-----------------------------");
    }
}

// Resume Screening System
public class ResumeScreeningSystem
{
    private List<object> resumes = new List<object>();  // FIX: Use List<object> to store any resume type

    // Generic method to process resumes dynamically
    public void ProcessResume<T>(Resume<T> resume) where T : JobRole
    {
        resumes.Add(resume);
        Console.WriteLine($"Resume for {resume.CandidateName} (Role: {resume.JobRole.RoleName}) added successfully.");
    }

    // Display all resumes
    public void DisplayResumes()
    {
        Console.Clear();
        Console.WriteLine("===== Processed Resumes =====");

        if (resumes.Count == 0)
        {
            Console.WriteLine("No resumes available.\n");
        }
        else
        {
            foreach (var resume in resumes)
            {
                // FIX: Correct casting and type checking
                switch (resume)
                {
                    case Resume<SoftwareEngineer> seResume:
                        seResume.DisplayResume();
                        break;
                    case Resume<DataScientist> dsResume:
                        dsResume.DisplayResume();
                        break;
                    default:
                        Console.WriteLine("Unknown resume type.");
                        break;
                }
            }
        }
        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }
}

// Main Program with Menu
public class Program
{
    public static void Main()
    {
        var screeningSystem = new ResumeScreeningSystem();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("===== AI-Driven Resume Screening System =====");
            Console.WriteLine("1. Submit a Resume");
            Console.WriteLine("2. Display Resumes");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SubmitResumeMenu(screeningSystem);
                    break;
                case "2":
                    screeningSystem.DisplayResumes();
                    break;
                case "3":
                    exit = true;
                    Console.WriteLine("Exiting the system...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Menu for submitting resumes
    private static void SubmitResumeMenu(ResumeScreeningSystem screeningSystem)
    {
        Console.Clear();
        Console.WriteLine("===== Submit a Resume =====");
        Console.Write("Enter Candidate Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Candidate Skills: ");
        string skills = Console.ReadLine();

        Console.WriteLine("Select Job Role:");
        Console.WriteLine("1. Software Engineer");
        Console.WriteLine("2. Data Scientist");
        Console.Write("Enter your choice: ");
        string roleChoice = Console.ReadLine();

        switch (roleChoice)
        {
            case "1":
                var softwareEngineerResume = new Resume<SoftwareEngineer>(name, skills, new SoftwareEngineer());
                screeningSystem.ProcessResume(softwareEngineerResume);
                break;
            case "2":
                var dataScientistResume = new Resume<DataScientist>(name, skills, new DataScientist());
                screeningSystem.ProcessResume(dataScientistResume);
                break;
            default:
                Console.WriteLine("Invalid job role selection.");
                break;
        }

        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine();
    }
}
