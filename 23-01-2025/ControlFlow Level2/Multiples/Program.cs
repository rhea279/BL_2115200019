using System;
class Multiples{
	static void Main(){
    	//Input a number from user
    	Console.Write("Enter a number :");
    	int number = Convert.ToInt32(Console.ReadLine());
    	FindingMultiples(number);
	}
	//Find multiples of number taken using for loop
	static void FindingMultiples(int n){
    	Console.Write($"Multiples of {n} :");
    	for(int i = 100 ; i >= 1 ; i--){
        	if(i % n == 0){
            	Console.WriteLine(i);
            	continue;
        	}
    	}
	}
}

