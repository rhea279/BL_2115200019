using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter JSON File Path:");
        string jsonString = File.ReadAllText(Console.ReadLine());
        JArray users = JArray.Parse(jsonString);

        var filteredUsers = users.Where(u => (int)u["age"] > 25);

        Console.WriteLine(JArray.FromObject(filteredUsers).ToString());
    }
}
