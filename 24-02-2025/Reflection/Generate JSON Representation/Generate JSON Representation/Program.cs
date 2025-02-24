using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JSON_Generator
{
    class Person
    {
        public string Name;
        public int Age;
        public double Salary;

        public Person(string name, int age, double salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }
    }

    class JsonConverter
    {
        public static string ToJson(object obj)
        {
            if (obj == null)
                return "{}";

            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");

            List<string> jsonFields = new List<string>();

            foreach (var field in fields)
            {
                object value = field.GetValue(obj);
                string formattedValue = FormatValue(value);
                jsonFields.Add($"\"{field.Name}\": {formattedValue}");
            }

            jsonBuilder.Append(string.Join(", ", jsonFields));
            jsonBuilder.Append("}");

            return jsonBuilder.ToString();
        }

        private static string FormatValue(object value)
        {
            if (value is string)
                return $"\"{value}\"";
            else if (value is bool)
                return value.ToString().ToLower();
            else
                return value.ToString();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("John Doe", 30, 55000.50);
            string json = JsonConverter.ToJson(person);
            Console.WriteLine("JSON Representation:");
            Console.WriteLine(json);
        }
    }
}
