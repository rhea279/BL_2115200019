using System;
class Program05{
	static void Main(string[] args){
		string r= Console.ReadLine();
		string h = Console.ReadLine();
		double radius = double.Parse(r); 
		double height = double.Parse(h);
		double volume= Math.PI * Math.Pow(radius, 2)*height; 
		Console.WriteLine($"The volume of cylinder is: {volume}");
	}
}
