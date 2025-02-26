using System;
using System.IO;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;


namespace Validate_JSON_stucture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Schema File:");
            string schemaText = File.ReadAllText(Console.ReadLine());
            Console.WriteLine("Enter Json File:");
            string jsonString = File.ReadAllText(Console.ReadLine());

            JSchema schema = JSchema.Parse(schemaText);
            JObject jsonData = JObject.Parse(jsonString);

            if (jsonData.IsValid(schema))
            {
                Console.WriteLine("JSON is Valid!");
            }
            else
            {
                Console.WriteLine("Invalid JSON!");
            }
        }
    }
}
