
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Validate_a_License_Plate_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter License Plate Number:");
            string license = Console.ReadLine();
            Console.WriteLine("Valid License Plate Number:"+isValidLicense(license));
        }
        static bool isValidLicense(string license)
        {
            string pattern = @"^[A-Z]{2}\d{4}$";
            return Regex.IsMatch(license, pattern);
        }
        }
}
