using System;
class HarshadNumber{
	static void Main() {
    	// Input a number from user
    	Console.Write("Enter an integer: ");
    	int number = Convert.ToInt32(Console.ReadLine());

    	// Call method to check if the number is a Harshad number
    	bool isHarshad = CheckHarshad(number);

    	// Display the result
    	if (isHarshad) {
        	Console.WriteLine($"{number} is a Harshad Number.");
    	} else {
        	Console.WriteLine($"{number} is not a Harshad Number.");
    	}
	}

	static bool CheckHarshad(int number) {
    	// Handle negative numbers
    	number = Math.Abs(number);

    	// Initialize sum variable
    	int sum = 0;
    	int originalNumber = number;

    	// Calculate the sum of digits
    	while (originalNumber != 0) {
        	int digit = originalNumber % 10; // Get the last digit
        	sum += digit; // Add the digit to the sum
        	originalNumber /= 10; // Remove the last digit
    	}

    	// Check if the number is divisible by the sum of its digits
    	return (number % sum == 0);
	}
}