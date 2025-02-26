using Newtonsoft.Json;
using System;
using System.Collections.Generic;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "John", Age = 21 },
            new Student { Name = "Emma", Age = 22 }
        };

        string jsonString = JsonConvert.SerializeObject(students, Formatting.Indented);
        Console.WriteLine(jsonString);
    }
}
