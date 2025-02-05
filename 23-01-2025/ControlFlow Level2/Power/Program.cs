using System;
class Power{
	static void Main(){
    	//Input a number from user
    	Console.Write("Enter a number :");
    	int n = Convert.ToInt32(Console.ReadLine());
    	//Input power from user
    	Console.Write("Enter power :");
    	int power = Convert.ToInt32(Console.ReadLine());
    	FindPower(n,power);
	}
	static void FindPower(int n, int power){
    	//Create a result variable with an initial value of 1
    	int result = 1;
    	for(int i = 1; i <= power ; i++){
        	result *= n;
    	}
    	Console.Write($"{power} power of  {n} is : {result}");
	}
}