using Newtonsoft.Json;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter JSON File Path:");
        string jsonString = File.ReadAllText(Console.ReadLine());
        dynamic user = JsonConvert.DeserializeObject(jsonString);

        Console.WriteLine("User Name: " + user.name);
        Console.WriteLine("Skills: " + string.Join(", ", user.skills));
    }
}
