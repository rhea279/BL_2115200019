using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

class Program
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    static void Main()
    {
        Console.WriteLine("Enter Connection:");
        string connectionString = Console.ReadLine();
        List<Employee> employees = new List<Employee>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Id, Name, Age FROM Employees", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                employees.Add(new Employee
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Age = reader.GetInt32(2)
                });
            }
        }

        string jsonString = JsonConvert.SerializeObject(employees, Formatting.Indented);
        File.WriteAllText("report.json", jsonString);

        Console.WriteLine("JSON report generated!");
    }
}
