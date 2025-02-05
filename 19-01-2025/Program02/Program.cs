using System;
class Program02{
	static void Main(string[] args){
		string input1 = Console.ReadLine();
		string input2 = Console.ReadLine();
    	int n1 = int.Parse(input1);
    	int n2 = int.Parse(input2);
		int sum = n1+n2;
		Console.WriteLine($"The sum of {n1} and {n2} is {sum}");
	}
}
