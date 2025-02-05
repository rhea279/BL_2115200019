using System;
class Program03{
	static void Main(string[] args){
		string cel= Console.ReadLine();
		int celsius= int.Parse(cel);
		int fah = (celsius * 9/5) + 32;
		Console.WriteLine($"Fahrenheit = {fah}");
	}
}
