using Newtonsoft.Json.Linq;
using System;


class Program
{
    static void Main()
    {
        string json1 = "{ \"name\": \"Alice\", \"age\": 25 }";
        string json2 = "{ \"email\": \"alice@example.com\", \"city\": \"New York\" }";

        JObject obj1 = JObject.Parse(json1);
        JObject obj2 = JObject.Parse(json2);

        obj1.Merge(obj2, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union });

        Console.WriteLine(obj1.ToString());
    }
}
