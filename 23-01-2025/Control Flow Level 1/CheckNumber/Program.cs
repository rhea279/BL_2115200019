using System;
class CheckNumber{
	static void Main(){
    	//Get the number input from the user
    	Console.Write("Enter the number:");
    	int n = Convert.ToInt32(Console.ReadLine());
    	CheckingNum(n);
	}
	//Checking if number is Positive, Negative or Zero
	static void CheckingNum(int n){
    	if(n>0){
        	Console.WriteLine($"{n} is Positive");
    	}
    	else if(n<0){
        	Console.WriteLine($"{n} is Negative");
    	}
    	else{
        	Console.WriteLine($"{n} is Zero");
    	}
	}
}

