using System;
class SimpleInterest{
	static void Main(string[] args){
		//Input the Principal from the User
		Console.Write("Enter the Principal:");
		double principal  = Double.Parse(Console.ReadLine());
		//Input the Rate of Interest
		Console.Write("Enter the Rate of Interest:");
		double rate = Double.Parse(Console.ReadLine());
		//Input the TIme of Interest
		Console.Write("Enter the Time of Interest:");
		double time = Double.Parse(Console.ReadLine());
		
		//Calculate the Simple Interest
		double si = (principal*rate*time)/100;
		Console.Write($"The Simple Interest is {si} for Principal {principal}, Rate of Interest {rate} and Time {time}");
	}
}