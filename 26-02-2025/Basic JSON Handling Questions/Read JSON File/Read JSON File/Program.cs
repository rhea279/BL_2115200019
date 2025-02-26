using System;
using Newtonsoft.Json;
using System.IO;

namespace Read_JSON_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter json file path:");
            string jsonString = File.ReadAllText(Console.ReadLine());
            dynamic user = JsonConvert.DeserializeObject(jsonString);

            Console.WriteLine("Name :" + user.name);
            Console.WriteLine("Email :" + user.email);
        }
    }
}
