using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;


class Program
{
    static void Main()
    {
        Console.WriteLine("Enter File:");
        string jsonString = File.ReadAllText(Console.ReadLine());
        JObject jsonData = JObject.Parse(jsonString);

        XDocument xml = JsonConvert.DeserializeXNode(jsonData.ToString(), "Root");
        Console.WriteLine(xml);
    }
}
