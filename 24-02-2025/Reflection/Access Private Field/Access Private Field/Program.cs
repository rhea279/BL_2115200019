using System;
using System.Reflection;

namespace Access_Private_Field
{
    class Person
    {
        private int age;

        public Person(int initialAge)
        {
            age = initialAge;
        }

        public void ShowAge()
        {
            Console.WriteLine($"Person's age is: {age}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(25);
            person.ShowAge();

            Type type = typeof(Person);
            FieldInfo ageField = type.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);

            if (ageField != null)
            {
                int currentAge = (int)ageField.GetValue(person);
                Console.WriteLine($"\nCurrent Private Age: {currentAge}");

                ageField.SetValue(person, 30);
                Console.WriteLine("Private field 'age' updated to 30.\n");

                person.ShowAge(); 
            }
            else
            {
                Console.WriteLine("Error: Private field 'age' not found.");
            }
        }
    }
}
