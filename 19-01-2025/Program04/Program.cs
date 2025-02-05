using System;
class Program04{
	static void Main(string[] args){
		string r= Console.ReadLine();
		double radius = double.Parse(r); 
		double area = Math.PI * Math.Pow(radius, 2); 
		Console.WriteLine($"The area of the circle with radius {radius} is: {area}");
	}
}
