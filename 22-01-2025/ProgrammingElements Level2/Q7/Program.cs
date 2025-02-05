using System;
class Swap{
	static void Main(string[] args){
		//Input number1 and number 2 from the User
		Console.Write("Enter the number1:");
		int n1 = Int32.Parse(Console.ReadLine());
		Console.Write("Enter the number2:");
		int n2 = Int32.Parse(Console.ReadLine());
		//Swapping the two numbers
		n1 = n1+n2;
		n2 = n1- n2;
		n1 = n1 - n2;
		//Display the swapped numbers
		Console.Write($"The swapped numbers are {n1} and {n2}");
		
	}
}