using System;
class Program2
{
	static void Main(string[] args)
	{
    	Console.Write("Enter length of the rectangle: ");
    	string lengthIn = Console.ReadLine();
    	Console.Write("Enter width of the rectangle: ");
    	string widthIn = Console.ReadLine();

    	double length = double.Parse(lengthIn);
    	double width = double.Parse(widthIn);
    	double perimeter = 2 * (length + width);

    	Console.WriteLine($"The perimeter of the rectangle with length {length} and width {width} is: {perimeter}");
	}
}
