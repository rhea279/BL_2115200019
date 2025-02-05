using System;
class PrimeNum{
	static void Main(){
    	//Input the number from User
    	Console.Write("Enter a number :");
    	int n = Convert.ToInt32(Console.ReadLine());
    	//boolean variable to store the result
    	bool isPrime = CheckPrime(n);
    	//Display result
    	Console.Write($"{n} is a Prime Number? {isPrime}");
	}
	static bool CheckPrime(int n){
    	if(n>1){
        	for(int i = 2; i < n; i++){
            	if(n%i == 0){
                	return false;
                	break;
            	}
        	}
        	return true;
    	}else{
        	return false;
    	}
	}
}

