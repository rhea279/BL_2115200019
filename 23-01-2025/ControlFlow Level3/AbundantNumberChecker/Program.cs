using System;

class AbundantNumberChecker {
	static void Main() {
    	// Input a number from user
    	Console.Write("Enter an integer: ");
    	int number = Convert.ToInt32(Console.ReadLine());

    	// Call method to check if the number is an Abundant number
    	bool isAbundant = CheckAbundant(number);

    	// Display the result
    	if (isAbundant) {
        	Console.WriteLine($"{number} is an Abundant Number.");
    	} else {
        	Console.WriteLine($"{number} is not an Abundant Number.");
    	}
	}

	static bool CheckAbundant(int number) {
    	// Handle negative numbers
    	if (number <= 0) return false;

    	// Initialize sum variable
    	int sum = 0;

    	// Calculate the sum of divisors
    	for (int i = 1; i < number; i++) {
        	if (number % i == 0) { // Check if i is a divisor
            	sum += i; // Add the divisor to the sum
        	}
    	}

    	// Check if the sum of divisors is greater than the number
    	return (sum > number);
	}
}

