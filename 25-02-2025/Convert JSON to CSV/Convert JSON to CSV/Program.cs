using System;
using System.Data.SqlClient;
using System.IO;

class Program
{
    static void Main()
    {
        string connectionString = "your_connection_string_here";
        string query = "SELECT EmployeeID, Name, Department, Salary FROM Employees";
        Console.WriteLine("Enter CSV output file path:");
        string outputFilePath = Console.ReadLine();

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    // Writing headers
                    writer.WriteLine("EmployeeID,Name,Department,Salary");

                    // Writing data rows
                    while (reader.Read())
                    {
                        writer.WriteLine($"{reader["EmployeeID"]},{reader["Name"]},{reader["Department"]},{reader["Salary"]}");
                    }
                }
            }
            Console.WriteLine($"CSV file generated successfully: {outputFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
