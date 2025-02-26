using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.IO;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        string schemaText = @"
        {
          'type': 'object',
          'properties': {
            'email': { 'type': 'string', 'format': 'email' }
          },
          'required': ['email']
        }";

        Console.WriteLine("Enter JSON File Path:");
        string jsonString = File.ReadAllText(Console.ReadLine());

        JObject jsonData = JObject.Parse(jsonString);
        JSchema schema = JSchema.Parse(schemaText);

        if (jsonData.IsValid(schema))
            Console.WriteLine("Valid email format.");
        else
            Console.WriteLine("Invalid email format.");
    }
}
