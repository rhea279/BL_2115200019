using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter CSV File Path:");
        string[] lines = File.ReadAllLines(Console.ReadLine());
        var csvData = new List<Dictionary<string, string>>();
        string[] headers = lines[0].Split(',');

        for (int i = 1; i < lines.Length; i++)
        {
            var dict = new Dictionary<string, string>();
            string[] values = lines[i].Split(',');

            for (int j = 0; j < headers.Length; j++)
                dict[headers[j]] = values[j];

            csvData.Add(dict);
        }

        string jsonString = JsonConvert.SerializeObject(csvData, Formatting.Indented);
        Console.WriteLine(jsonString);
    }
}
