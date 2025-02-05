using System;
class Factor{
	static void Main(){
    	//Input a number from user
    	Console.Write("Enter a number :");
    	int n = Convert.ToInt32(Console.ReadLine());
    	FindFactor(n);
	}
	//Finding the greatest factor
	static void FindFactor(int n){
    	//Define a greatestFactor variable and assign it to 1
    	int greatestFactor = 1;
    	for(int i = n-1 ; i >=1 ;i--){
        	if(n%i == 0){
            	greatestFactor = i;
            	break;
        	}
    	}
    	Console.Write($"{greatestFactor} is the greatest factor of {n}");
	}
}