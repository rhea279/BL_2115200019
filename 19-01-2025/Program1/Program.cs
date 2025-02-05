using System;
class Program1{
	static void Main(string[] args){
    	Console.Write("Enter Principal Amount:");
    	string principalIn = Console.ReadLine();
   	Console.Write("Enter Rate of Interest:");
    	string interest = Console.ReadLine();
    	Console.Write("Enter Time Period:");
    	string timeIn = Console.ReadLine();
    	double principal = double.Parse(principalIn);
    	double rate = double.Parse(interest);
    	double time = double.Parse(timeIn);
    	double SI = (principal * rate * time) / 100;
    	Console.WriteLine($"The Simple Interest is : {SI}");
	}
}
