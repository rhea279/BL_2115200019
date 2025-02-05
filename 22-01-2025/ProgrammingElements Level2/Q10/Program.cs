using System;
class DivideChoc{
	static void Main(string[] args){
		//Input the number of Chocolates 
		Console.Write("Enter the number of Chocolates:");
		int numberOfChocolates  = Int32.Parse(Console.ReadLine());
		//Input the number of Children 
		Console.Write("Enter the number of Children:");
		int numberOfChildren  = Int32.Parse(Console.ReadLine());
		//Compute the number of chocolates each child gets and the number of remaining chocolates
		int chocPerChild = numberOfChocolates/numberOfChildren;
		int remaining = numberOfChocolates%numberOfChildren;
		//Display the result
		Console.Write($"The number of chocolates each child gets is {chocPerChild} and the number of remaining chocolates is {remaining}");
	}
}