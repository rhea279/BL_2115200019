using System;
class DoubleOpt{
	static void Main(string[] args){
		//Input the three integers a,b and c from the User
		Console.Write("Enter a :");
		double a = Double.Parse(Console.ReadLine());
		Console.Write("Enter b :");
		double b = Double.Parse(Console.ReadLine());
		Console.Write("Enter c :");
		double c = Double.Parse(Console.ReadLine());
		
		(double one,double two,double three,double four) = Operations(a,b,c);
		Console.WriteLine($"The results of Double Operations are {one}, {two}, {three} and {four}");
	}
	//Performing the given integer operations
	static (double,double,double,double) Operations(double a, double b, double c){
		double one = a + b * c;
		double two = a * b + c ;
		double three = c + a / b;
		double four = a % b + c;
		return (one,two,three,four);
	}
}