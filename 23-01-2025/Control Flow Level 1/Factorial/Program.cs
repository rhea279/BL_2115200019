using System;
class Factorial{
	static void Main(){
    	//Input from User
    	Console.Write("Enter the number :");
    	int n = Convert.ToInt32(Console.ReadLine());
    	FactorialN(n);
	}
	// find the factorial of an integer entered by the user.
	static void FactorialN(int n){
    	int fact = 1;
    	while(n>=1){
        	fact *= n;
        	n--;
    	}
    	Console.Write($"Factorial : {fact}");
	}
}