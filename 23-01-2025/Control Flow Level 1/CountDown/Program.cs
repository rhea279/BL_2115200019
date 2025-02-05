using System;
class CountDown{
	static void Main(){
    	//Input the counter start from User
    	Console.Write("Enter the count down number:");
    	int counter = Convert.ToInt32(Console.ReadLine());
    	Count(counter);
	}
	// Creating a Count Down Launch
	static void Count(int counter){
    	Console.Write("Launch In :");
    	while(counter!=0){
        	Console.WriteLine($"{counter}");
        	counter--;
    	}
	}
}