using System;
class DigitCounter {
	static void Main() {
    	// Input a number from user
    	Console.Write("Enter an integer: ");
    	int number = Convert.ToInt32(Console.ReadLine());

    	// Call method to count digits
    	int digitCount = CountDigits(number);

    	// Display the result
    	Console.WriteLine($"The number of digits in {number} is: {digitCount}");
	}

	static int CountDigits(int number) {
    	// Handle negative numbers
    	number = Math.Abs(number);

    	// Initialize count variable
    	int count = 0;

    	// Process each digit of the number
    	do {
        	number /= 10; // Remove the last digit
        	count++; // Increment count
    	} while (number != 0);

    	return count;
	}
}

