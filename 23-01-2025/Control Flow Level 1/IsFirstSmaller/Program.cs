using System;
class IsFirstSmaller{
	static void Main(string[] args){
    	//Input the three number from user:
    	Console.Write("Enter the three numbers:");
    	int n1 = Int32.Parse(Console.ReadLine());
    	int n2 = Int32.Parse(Console.ReadLine());
    	int n3 = Int32.Parse(Console.ReadLine());
   	 
    	//Checking if first number is smzllest among the three
    	if(n1<n2 && n1<n3){
        	Console.Write($"Yes, {n1} is smallest of 3 numbers");
    	}else{
        	Console.Write($"No, {n1} is not smallest of 3 numbers");
    	}
	}
}