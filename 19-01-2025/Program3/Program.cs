using System;
class Program3
{
	static void Main(string[] args)
	{
    	Console.Write("Enter the base number: ");
    	string baseIn = Console.ReadLine();
    	Console.Write("Enter the exponent: ");
    	string exponentIn = Console.ReadLine();

    	double baseNumber = double.Parse(baseIn);
    	double exponent = double.Parse(exponentIn);
    	double result = Math.Pow(baseNumber, exponent);

    	Console.WriteLine($"{baseNumber} raised to the power of {exponent} is: {result}");
	}
}
