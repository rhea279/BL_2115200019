using System;
class Multiplication{
	static void Main(){
    	//Input the integer
    	Console.Write("Enter a number :");
    	int n = Convert.ToInt32(Console.ReadLine());
    	Multiply(n);
	}
	static void Multiply(int n){
    	for(int i = 6; i <= 9 ;i++){
        	Console.WriteLine($"{n} x {i} = {n*i}");
    	}
	}
}



