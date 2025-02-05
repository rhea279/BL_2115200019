using System;

class Armstrong {
	static void Main() {
    	// Input a number from user
    	Console.Write("Enter a number: ");
    	int number = Convert.ToInt32(Console.ReadLine());

    	// Call method to check Armstrong number
    	CheckArmstrong(number);
	}

	static void CheckArmstrong(int number) {
    	// Initialize sum variable and store the original number
    	int sum = 0;
    	int originalNumber = number;

    	// Process each digit of the number
    	while (originalNumber != 0) {
        	// Get the last digit of the number
        	int remainder = originalNumber % 10;

        	// Add the cube of the digit to the sum
        	sum += (int)Math.Pow(remainder, 3);

        	// Remove the last digit from the number
        	originalNumber /= 10;
    	}

    	// Check if the sum equals the original number
    	if (number == sum) {
        	Console.WriteLine($"{number} is an Armstrong Number.");
    	} else {
        	Console.WriteLine($"{number} is not an Armstrong Number.");
    	}
	}
}

