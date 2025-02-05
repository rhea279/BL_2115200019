using System;

class Frequency
{
    static void Main()
    {
        // Take input for the number
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Check if the number is negative, as we're only interested in non-negative integers
        if (number < 0)
        {
            Console.WriteLine("Please enter a positive number.");
        }
        else
        {
            // Call the method to calculate and display the frequency of each digit
            DisplayFrequency(number);
        }
    }

    static void DisplayFrequency(int number)
    {
        // Create a frequency array to store the count of each digit (0-9)
        int[] frequency = new int[10];

        // Temporary variable to store the number while extracting digits
        int temp = number;

        // Special case: If the number is 0, handle it separately
        if (temp == 0)
        {
            frequency[0]++;
        }

        // Loop to extract digits and increment their respective frequencies
        while (temp != 0)
        {
            int digit = temp % 10;  // Get the last digit
            frequency[digit]++;     // Increment the frequency of the digit
            temp /= 10;             // Remove the last digit
        }

        // Display the frequency of each digit
        Console.WriteLine("\nDigit frequencies:");
        for (int i = 0; i < 10; i++)
        {
            if (frequency[i] > 0)
            {
                Console.WriteLine($"Digit {i}: {frequency[i]} time(s)");
            }
        }
    }
}
