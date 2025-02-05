using System;
class OddEven{
	static void Main(){
    	//Input the number from User
    	Console.Write("Enter a number :");
    	int n = Convert.ToInt32(Console.ReadLine());
    	if(n > 0) { // Check if it's a natural number
        	OddEvenNum(n);
    	} else {
        	Console.WriteLine("Please enter a natural number (greater than 0).");
    	}
	}
	static void OddEvenNum(int n){
    	for(int i = 1; i <= n ; i++){
        	if(i%2 == 0){
            	Console.WriteLine(i+" is Even ");
        	}
        	else{
            	Console.WriteLine(i+" is Odd ");
        	}
    	}
	}
}