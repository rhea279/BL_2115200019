using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dynamically_Create_Objects
{
    class Student
    {
        public string Name;
        public int Id;
        public Student()
        {
            Id = 0;
            Name = null;
        }
        public Student(string name, int id)
        {
            Name = name;
            Id = id;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Name:{Name}, Student Id: {Id}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Type studentType = typeof(Student);
            object createInstance = Activator.CreateInstance(studentType);

            if (createInstance != null)
            {
                Console.WriteLine("Student Object Created Dynamically!");
                MethodInfo displayMethod = studentType.GetMethod("DisplayInfo");
                displayMethod.Invoke(createInstance  , null);
            }
            else
            {
                Console.WriteLine("Failed to create Student Object.");
            }
        }
    }
}
