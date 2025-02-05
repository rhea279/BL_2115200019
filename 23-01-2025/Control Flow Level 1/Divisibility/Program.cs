using System;
class Divisibility{
	static void Main(string[] args){
    	//Input number by User
    	Console.Write("Enter the number :");
    	int n = Int32.Parse(Console.ReadLine());
    	//Check if number is divisible by 5
    	if(n%5 == 0){
        	Console.WriteLine($"{n} is divisible by 5");
    	}
    	else{
        	Console.WriteLine($"{n} is not divisible by 5");
    	}
	}
}