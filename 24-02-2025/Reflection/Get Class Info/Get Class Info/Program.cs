
using System;
using System.Reflection;
namespace Get_Class_Info
{
    class Info
    {
        public int Id;
        public string Name;

        public Info() { }
        public Info(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}");
        }
        private void HiddenMethod()
        {
            Console.WriteLine("This is a private method.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the class name:");
            string className = Console.ReadLine();
            try
            {

                Type type = Type.GetType($"Get_Class_Info.{className}");
                if (type == null)
                {
                    Console.WriteLine("Error: Class not found");
                    return;
                }
                Console.WriteLine($"\nClass: {type.Name}\n");
                Console.WriteLine(" Fields:");
                FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (var field in fields)
                {
                    Console.WriteLine($"  - {field.FieldType} {field.Name}");
                }

                // Display Methods
                Console.WriteLine("\nMethods:");
                MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var method in methods)
                {
                    Console.WriteLine($"  - {method.ReturnType} {method.Name}()");
                }

                // Display Constructors
                Console.WriteLine("\nConstructors:");
                ConstructorInfo[] constructors = type.GetConstructors();
                foreach (var constructor in constructors)
                {
                    Console.WriteLine($"  - {constructor.Name}()");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

