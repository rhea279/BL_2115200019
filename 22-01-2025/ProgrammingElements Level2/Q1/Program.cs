using System;
class QuotientRemainder{
	static void Main(string[] args){
		//Input the two numbers from the user 
		Console.WriteLine("Enter first number:");
		int n1 = Int32.Parse(Console.ReadLine());
		Console.WriteLine("Enter second number:");
		int n2 = Int32.Parse(Console.ReadLine());
		
		 (int quotient, int remainder) = Division(n1, n2);
        Console.WriteLine($"The Quotient is {quotient} and Remainder is {remainder} of two numbers {n1} and {n2}");
    }
	//Calculate the quotient and remainder using division and modulus operator
	static (int,int) Division(int n1, int n2){
		int quotient = n1/n2;
		int remainder = n1%n2;
		return (quotient,remainder);
	}
}