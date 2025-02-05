using System;
class FactorialFor{
	static void Main(){
    	//Input from User
    	Console.Write("Enter the number :");
    	int n = Convert.ToInt32(Console.ReadLine());
    	FactorialN(n);
	}
	// find the factorial of an integer entered by the user using For Loop.
	static void FactorialN(int n){
    	int fact = 1;
    	for(int i = n ; i>=1 ;i--){
        	fact *= i;
    	}
    	Console.Write($"Factorial : {fact}");
	}
}