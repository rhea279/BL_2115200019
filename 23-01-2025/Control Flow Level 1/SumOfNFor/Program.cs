using System;
class SumOfN{
	static void Main(){
    	//Input from User
    	Console.Write("Enter the number :");
    	int n = Convert.ToInt32(Console.ReadLine());
    	if(n > 0) { // Check if it's a natural number
        	Sum(n);
    	} else {
        	Console.WriteLine("Please enter a natural number (greater than 0).");
    	}
	}
	//Find the sum of n natural numbers using For loop
	static void Sum(int n){
    	int sumFor = 0;
    	int sum = n*(n+1)/2;
    	int nOG = n;
    	for(int i = n;i>=1;i--){
        	sumFor += i;
    	}
   	 
    	if(sum == sumFor){
        	Console.Write($"Sum of {nOG} natural numbers is {sum}.Yes, the answer is same");
    	}
    	else{
        	Console.Write("No the sum from formulae and while loop is not the same.");
    	}
	}
}

