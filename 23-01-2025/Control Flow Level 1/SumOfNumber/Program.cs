using System;
class SumOfNumber{
	static void Main(){
    	//Input from User
    	Console.WriteLine("Enter the number:");
    	double n = Convert.ToDouble(Console.ReadLine());
    	Console.WriteLine($"Toatl Sum of Numbers : {SumNum(n):F2}");
   	 
	}
	static double SumNum(double n){
    	double total = 0.0;
    	while(n !=0){
        	total += n;
        	Console.WriteLine("Enter the number:");
        	n = Convert.ToDouble(Console.ReadLine());
    	}
    	return total;
	}
}

