using System;
class FindFactor{
	static void Main(){
    	//Input a number from user
    	Console.Write("Enter a number :");
    	int n = Convert.ToInt32(Console.ReadLine());
    	FindingFactors(n);
	}
	//Find factors of n using for loop
	static void FindingFactors(int n){
    	Console.Write($"Factors of {n} :");
    	for(int i = 1 ; i < n; i++){
        	if(n % i == 0){
            	Console.WriteLine(i);
        	}
    	}
	}
}

