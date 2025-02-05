using System;
class FizzBuzz{
	static void Main(){
    	//Input the number from User
    	Console.Write("Enter a number :");
    	int n = Convert.ToInt32(Console.ReadLine());
    	Printing(n);
	}
	static void Printing(int n){
    	if(n > 0){
    	if(n % 3 == 0){
        	for(int i = 0; i <= n;i++){
            	Console.WriteLine("Fizz");
        	}
    	}
    	else if(n % 5 == 0){
        	for(int i = 0; i <= n;i++){
            	Console.WriteLine("Buzz");
        	}
    	}
    	else{
        	for(int i = 0; i <= n;i++){
            	Console.WriteLine(i);
        	}
    	}
    	}else{
        	Console.WriteLine("Enter a valid number");
    	}
	}
}