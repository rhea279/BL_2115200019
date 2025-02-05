using System;
class IntOperations{
	static void Main(string[] args){
		//Input the three integers a,b and c from the User
		Console.Write("Enter a :");
		int a = Int32.Parse(Console.ReadLine());
		Console.Write("Enter b :");
		int b = Int32.Parse(Console.ReadLine());
		Console.Write("Enter c :");
		int c = Int32.Parse(Console.ReadLine());
		
		(int one,int two,int three,int four) = Operations(a,b,c);
		Console.WriteLine($"The results of Int Operations are {one}, {two}, {three} and {four}");
	}
	//Performing the given integer operations
	static (int,int,int,int) Operations(int a, int b, int c){
		int one = a + b * c;
		int two = a * b + c ;
		int three = c + a / b;
		int four = a % b + c;
		return (one,two,three,four);
	}
}