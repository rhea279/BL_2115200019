using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational_Course_Hierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt user for course details
            Console.Write("Enter Course Name: ");
            string courseName = Console.ReadLine();

            Console.Write("Enter Duration (in weeks): ");
            int duration = int.Parse(Console.ReadLine());

            Console.Write("Enter Platform: ");
            string platform = Console.ReadLine();

            Console.Write("Is the course recorded? (true/false): ");
            bool isRecorded = bool.Parse(Console.ReadLine());

            Console.Write("Enter Course Fee: ");
            double fee = double.Parse(Console.ReadLine());

            Console.Write("Enter Discount Percentage: ");
            double discount = double.Parse(Console.ReadLine());

            // Create a PaidOnlineCourse object with user input
            PaidOnlineCourse paidCourse = new PaidOnlineCourse(courseName, duration, platform, isRecorded, fee, discount);
            Console.WriteLine("\nCourse Information:");
            paidCourse.DisplayInfo(); // Display course details
        }
    }
    //Define a superclass Course 
    class Course
    {
        public string CourseName { get; set; }
        public int Duration { get; set; }
        public Course(string courseName, int duration)
        {
            CourseName = courseName;
            Duration = duration;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine("Course Details:");
            Console.WriteLine($"Course Name: {CourseName}");
            Console.WriteLine($"Duration: {Duration} weeks");
        }
    }
    //Define subclass OnlineCourse 
    class OnlineCourse : Course { 
        public string Platform { get; set; }
        public bool IsRecorded {  get; set; }
        public OnlineCourse(string courseName, int duration, string platform, bool isRecorded)
            : base(courseName, duration) {
            Platform = platform;
            IsRecorded = isRecorded;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Platform: {Platform}");
            Console.WriteLine($"Recorded: {IsRecorded}");
        }
    }
    //Class PaidOnlineCourse extends OnlineCourse. 
    class PaidOnlineCourse : OnlineCourse
    {
        public double Fee { get; set; }
        public double Discount { get; set; }
        public PaidOnlineCourse(string courseName, int duration, string platform, bool isRecorded, double fee, double discount)
            : base(courseName, duration, platform, isRecorded)
        {
            Fee = fee;
            Discount = discount;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Course Fee: {Fee}INR");
            Console.WriteLine($"Discount: {Discount}%");
        }
    }
}
