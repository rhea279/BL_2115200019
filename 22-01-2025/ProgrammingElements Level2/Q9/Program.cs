using System;
class NumberOfRounds{
	static void Main(string[] args){
		//Input the sides of the triangle from user
		Console.Write("Enter the sides of the triangle in Km:");
		double s1 = Double.Parse(Console.ReadLine());
		double s2 = Double.Parse(Console.ReadLine());
		double s3 = Double.Parse(Console.ReadLine());
		
		double perimeter = s1+s2+s3;
		double rounds = 5.0/perimeter;
		
		Console.Write($"The total number of rounds the athlete will run is {rounds} to complete 5 km");
		
	}
}