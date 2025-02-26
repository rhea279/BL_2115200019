using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter First JSON FIle:");
        string json1 = File.ReadAllText(Console.ReadLine());
        Console.WriteLine("Enter Second JSON File:");
        string json2 = File.ReadAllText(Console.ReadLine());

        JObject obj1 = JObject.Parse(json1);
        JObject obj2 = JObject.Parse(json2);

        obj1.Merge(obj2, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union });

        Console.WriteLine(obj1.ToString());
    }
}
