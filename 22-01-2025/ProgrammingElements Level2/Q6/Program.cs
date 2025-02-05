using System;
class TotalIncome{
	static void Main(string[] args){
		//Input Salary and Bonus from the User
		Console.Write("Enter the Salary:");
		int salary = Int32.Parse(Console.ReadLine());
		Console.Write("Enter the Bonus:");
		int bonus = Int32.Parse(Console.ReadLine());

		//Compute income by adding salary and bonus and print the result.
		Console.WriteLine($"The salary is INR {salary} and bonus is INR {bonus}. Hence Total Income is INR {salary+bonus}");
	}
}