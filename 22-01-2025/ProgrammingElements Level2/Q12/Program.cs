using System;
class ConvertWt{
	static void Main(string[] args){
		//Input weight in pounds from user
		Console.Write("Enter the weight in pounds:");
		double pounds = Double.Parse(Console.ReadLine());
		//Convert weight in pounds to kilograms
		double kg = pounds/2.2;
		//Display result
		Console.Write($"The weight of the person in pounds is {pounds} and in kg is {kg:F2}");
	}
}