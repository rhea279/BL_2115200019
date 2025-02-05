using System;
class TemperatureConversion {
	static void Main(string[] args){
		//Input temperature in Fahrenheit from the User
		Console.Write("Enter the temperature in Fahrenheit:");
		double fahrenheit = Double.Parse(Console.ReadLine());
		Console.Write($"The {fahrenheit} Fahrenheit is {TempConversion(fahrenheit):F2} Celsius");
		
	}
	//Convert temperature from Fahrenheit to Celsius
	static double TempConversion(double fahrenheit){
		double cel = (fahrenheit - 32) * 5/9;
		return cel;
	}
}