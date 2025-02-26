
using System;
using Newtonsoft.Json;

namespace Basic_JSON_Handling
{
    internal class Program
    {
        static void Main()
        {
            var jsonStudent = new
            {
                name = "Rhea",
                age = "22",
                subject = new string[] { "Math", "Science", "Computer" }
            };
            string jsonString = JsonConvert.SerializeObject(jsonStudent,Formatting.Indented);
            Console.WriteLine(jsonString);
        }
    }
}
