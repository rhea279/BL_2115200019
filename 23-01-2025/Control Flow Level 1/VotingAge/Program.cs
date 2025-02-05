using System;
class VotingAge{
	static void Main(){
	//Input user age from User
	Console.Write("Enter the person's age :");
	int age = Convert.ToInt32(Console.ReadLine());
	CanVote(age);
	}
	static void CanVote(int age){
    	if(age >=18){
        	Console.Write($"The person's age is {age} and can vote.");
    	}
    	else{
        	Console.Write($"The person's age is {age} and cannot vote.");
    	}
	}
}

