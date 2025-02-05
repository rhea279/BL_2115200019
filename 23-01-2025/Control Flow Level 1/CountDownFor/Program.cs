using System;
class CountDownFor{
	static void Main(){
    	//Input the counter start from User
    	Console.Write("Enter the count down number:");
    	int counter = Convert.ToInt32(Console.ReadLine());
    	Count(counter);
	}
	// Creating a Count Down Launch Using For Loop
	static void Count(int counter){
    	Console.Write("Launch In :");
    	for(int i = counter ; i >=1 ;i--){
        	Console.WriteLine(i);
    	}
	}
}

