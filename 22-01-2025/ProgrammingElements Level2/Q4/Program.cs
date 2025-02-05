using System;
class TemperatureConversion {
	static void Main(string[] args){
		//Input temperature in Celsius from the User
		Console.Write("Enter the temperature in Celsius:");
		double cel = Double.Parse(Console.ReadLine());
		Console.Write($"The {cel} Celsius is {TempConversion(cel)} Fahrenheit");
		
	}
	//Convert temperature from Celsius to Fahrenheit
	static double TempConversion(double cel){
		double fahrenheit = ((cel * 9/5) + 32);
		return fahrenheit;
	}
}