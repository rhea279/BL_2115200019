using System;
class FizzBuzz{
	static void Main(){
    	//Input the number from User
    	Console.Write("Enter a number :");
    	int n = Convert.ToInt32(Console.ReadLine());
    	Printing(n);
	}
	static void Printing(int n){
    	int nOg = n;
    	if(n > 0){
    	if(n % 3 == 0){
        	while(n>0){
            	Console.WriteLine("Fizz");
            	n--;
        	}
    	}
    	else if(n % 5 == 0){
        	while(n>0){
            	Console.WriteLine("Buzz");
            	n--;
        	}
    	}
    	else{
        	while(n>=0){
            	Console.WriteLine($"{nOg}");
            	n--;
        	}
    	}
    	}else{
        	Console.WriteLine("Enter a valid number");
    	}
	}
}

