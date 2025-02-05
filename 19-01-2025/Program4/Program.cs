using System;
class Program4{
	static void Main(string[] args){
    	Console.Write("Enter input 01:");
    	string n1 = Console.ReadLine();
    	Console.Write("Enter input 02:");
    	string n2 = Console.ReadLine();
    	Console.Write("Enter input 03:");
    	string n3 = Console.ReadLine();
   	 
    	double number1 = double.Parse(n1);
    	double number2 = double.Parse(n2);
    	double number3 = double.Parse(n3);
    	double average = (number1 + number2 + number3) / 3;

    	Console.WriteLine($"The average of {number1}, {number2}, and {number3} is: {average}");
	}
}
