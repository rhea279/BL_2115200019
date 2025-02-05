using System;
class SumOfNumber{
	static void Main(){
    	//Input from User
    	Console.WriteLine("Enter the number:");
    	double n = Convert.ToDouble(Console.ReadLine());
    	Console.WriteLine($"Toatl Sum of Numbers : {SumNum(n):F2}");
   	 
	}
	//Find the Total Sum of Numbers Input
	static double SumNum(double n){
    	double total = 0.0;
    	while(true){
        	total += n;
        	Console.WriteLine("Enter the number:");
        	n = Convert.ToDouble(Console.ReadLine());
        	if(n<=0){
            	break;
        	}
    	}
    	return total;
	}
}