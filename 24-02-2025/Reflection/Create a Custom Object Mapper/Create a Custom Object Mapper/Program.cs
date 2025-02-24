using System;
using System.Collections.Generic;
using System.Reflection;

namespace Custom_Object_Mapper
{
    class Person
    {
        public string Name;
        public int Age;
        public double Salary;

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Salary: {Salary}");
        }
    }

    class ObjectMapper
    {
        public static T ToObject<T>(Type clazz, Dictionary<string, object> properties) where T : new()
        {
            T instance = new T();

            foreach (var property in properties)
            {
                FieldInfo field = clazz.GetField(property.Key, BindingFlags.Public | BindingFlags.Instance);

                if (field != null && property.Value != null)
                {
                    try
                    {
                        object convertedValue = Convert.ChangeType(property.Value, field.FieldType);
                        field.SetValue(instance, convertedValue);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error setting field '{property.Key}': {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"Warning: Field '{property.Key}' not found in class '{clazz.Name}'");
                }
            }
            return instance;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, object> personData = new Dictionary<string, object>
            {
                { "Name", "John Doe" },
                { "Age", 30 },
                { "Salary", 55000.50 }
            };

            Person person = ObjectMapper.ToObject<Person>(typeof(Person), personData);
            person.DisplayInfo();
        }
    }
}
