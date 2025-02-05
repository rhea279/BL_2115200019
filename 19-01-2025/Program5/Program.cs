using System;
class Program5{
	static void Main(string[] args){
    	Console.Write("Enter distance in kilometers:");
    	string kilo = Console.ReadLine();
        	double kilometers = double.Parse(kilo);
    	double miles = kilometers*0.621371;
    	Console.WriteLine($"{kilometers} Kms is equal to {miles}miles.");
	}
}
