using System;
class VotingAge{
	static void Main(){
	// // Define an array to hold the ages of 10 students
    int[] studentAges = new int[10];
	for(int i = 0 ; i < 10 ; i++){
		Console.Write($"Enter the age of Student {i+1}:");
		if(int.TryParse(Console.ReadLine(), out int age)){
			studentAges[i] = age;
		}
		else{
			Console.WriteLine("Invalid Input.Please enter a valid integer.");
			i--;
		}
	}
	Console.WriteLine("Voting eligibility results :");
	foreach( int age in  studentAges){
		checkAge(age);
	}
	}
	//Checking if Student can vote or not
	static void checkAge(int age){
		if(age < 0){
			Console.WriteLine($"Invalid age.");
		}
		else if(age >= 18){
			Console.WriteLine($"Student with {age} age can vote.");
		}
		else{
			Console.WriteLine($"Student with {age} age cannot vote.");
		}
	}
	
}