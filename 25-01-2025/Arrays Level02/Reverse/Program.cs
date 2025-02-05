using System;

class Reverse
{
    static void Main()
    {
        // Take user input for the number
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Call the method to reverse the digits and display the result
        ReverseNumber(number);
    }

    static void ReverseNumber(int number)
    {
        // Check if the number is negative
        bool isNegative = number < 0;
        if (isNegative)
        {
            number = Math.Abs(number);  // Make the number positive for processing
        }

        // Count the digits in the number
        int count = 0;
        int temp = number;

        // Loop to count the number of digits
        while (temp != 0)
        {
            temp /= 10;
            count++;
        }

        // Create an array to store the digits
        int[] digits = new int[count];

        // Store the digits of the number in the array
        temp = number;
        for (int i = 0; i < count; i++)
        {
            digits[i] = temp % 10;  // Get the last digit
            temp /= 10;              // Remove the last digit
        }

        // Display the reversed number, handle negative number sign
        if (isNegative)
        {
            Console.Write("-");
        }

        // Print the reversed digits
        for (int i = 0; i < count; i++)
        {
            Console.Write(digits[i]);
        }
        Console.WriteLine();
    }
}
