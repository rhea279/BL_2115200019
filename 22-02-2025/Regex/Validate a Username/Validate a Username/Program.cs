using System;
using System.Text.RegularExpressions;

namespace Validate_a_Username
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter UserName:");
            string user= Console.ReadLine();
            Console.WriteLine("User Validity:"+isValidUsername(user));
        }
        static bool isValidUsername(string username)
        {
            string pattern = @"^[a-zA-Z][a-zA-Z0-9_]{4,14}$";
            return Regex.IsMatch(username, pattern);
        }
        }
}
