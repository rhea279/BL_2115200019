using System;
class NaturalNumber{
	static void Main(){
    	//Input the number from user
    	Console.Write("Enter the number :");
    	string n = Console.ReadLine();
    	if (int.TryParse(n, out int number))
    	{
        	// Check if the number is a positive integer
        	if (number > 0)
        	{
            	// Calculate the sum of the first n natural numbers
            	int sum = number * (number + 1) / 2;
            	Console.WriteLine($"The sum of {number} natural numbers is {sum}");
        	}
        	else
        	{
            	Console.WriteLine($"The number {number} is not a natural number");
        	}
    	}
    	else
    	{
        	Console.WriteLine("Please enter a valid integer.");
    	}
	}
}