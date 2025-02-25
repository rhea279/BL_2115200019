using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validate_CSV_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter File Path of CSV File:");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("❌ Error: The specified file does not exist.");
                return;
            }

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"; 
            string phonePattern = @"^\d{10}$";
            try
            {
                List<string> invalidRecords = new List<string>();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    bool isHeader = true;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (isHeader)
                        {
                            isHeader = false;
                            continue;
                        }
                        string[] columns = line.Split(',');
                        string id = columns[0].Trim();
                        string name = columns[1].Trim();
                        string email = columns[2].Trim();
                        string phoneNumber = columns[3].Trim();

                        bool isValidEmail = Regex.IsMatch(emailPattern, email);
                        bool isValidPhone = Regex.IsMatch(phonePattern, phoneNumber);

                        if (!isValidEmail || !isValidPhone)
                        {
                            string errorMessage = $"Invalid Record - ID: {id}, Name: {name}, Email: {email}, Phone: {phoneNumber}";

                            if (!isValidEmail)
                                errorMessage += " [Invalid Email Format]";

                            if (!isValidPhone)
                                errorMessage += " [Invalid Phone Number]";

                            invalidRecords.Add(errorMessage);


                        }
                    }
                    if (invalidRecords.Count > 0)
                    {
                        Console.WriteLine("\nInvalid Records Found:");
                        Console.WriteLine("--------------------------------------");
                        foreach (var record in invalidRecords)
                        {
                            Console.WriteLine(record);
                        }
                    }
                    else
                    {
                        Console.WriteLine("All records are valid!");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
