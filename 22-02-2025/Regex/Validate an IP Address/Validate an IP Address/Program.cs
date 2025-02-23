using System;
using System.Text.RegularExpressions;

class Program
{
    static bool IsValidIPAddress(string ip)
    {
        string pattern = @"^(25[0-5]|2[0-4][0-9]|1?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|1?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|1?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|1?[0-9][0-9]?)$";
        return Regex.IsMatch(ip, pattern);
    }

    static void Main()
    {
        Console.Write("Enter an IP address: ");
        string input = Console.ReadLine();

        Console.WriteLine(IsValidIPAddress(input) ? "Valid IP" : " Invalid IP");
    }
}
