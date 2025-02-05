using System;
class UserInput{
	static void Main(string[] args){
		//take user inputs for name, fromCity, viaCity, toCity
		Console.Write("Enter Name :");
		string name = Console.ReadLine();
		Console.Write("Enter fromCity :");
		string fromCity = Console.ReadLine();
		Console.Write("Enter viaCity :");
		string viaCity = Console.ReadLine();
		Console.Write("Enter toCity :");
		string toCity = Console.ReadLine();
		
		 Console.WriteLine("Enter the distance from the starting city to the via city (in miles):");
        double fromToVia = Double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the distance from the via city to the final city (in miles):");
        double viaToFinalCity = Double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the time taken for the journey (in hours):");
        double timeTaken = Double.Parse(Console.ReadLine());

        // Calculations
        double totalDistance = fromToVia + viaToFinalCity;
        double averageSpeed = totalDistance / timeTaken;

		Console.WriteLine($"Total Distance of the trip id {totalDistance} and average speed is {averageSpeed}");
		
	}
}