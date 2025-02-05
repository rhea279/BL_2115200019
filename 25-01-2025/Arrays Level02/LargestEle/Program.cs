using System;

class LargestEle
{
    static void Main()
    {
        // Take input from the user for the number
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Call the method to find the largest and second largest digits
        FindLargestAndSecondLargest(number);
    }

    static void FindLargestAndSecondLargest(int number)
    {
        // Define the maximum size for the digits array
        int maxDigit = 10;

        // Create an array to store the digits
        int[] digits = new int[maxDigit];

        // Initialize the index for the array
        int index = 0;

        // Loop to extract digits and store them in the array
        while (number != 0 && index < maxDigit)
        {
            digits[index] = number % 10; // Get the last digit
            number = number / 10;        // Remove the last digit
            index++;
        }

        // Variables to store the largest and second largest digits
        int largest = -1, secondLargest = -1;

        // Loop through the array to find the largest and second largest digits
        for (int i = 0; i < index; i++)
        {
            if (digits[i] > largest)
            {
                secondLargest = largest;
                largest = digits[i];
            }
            else if (digits[i] > secondLargest && digits[i] < largest)
            {
                secondLargest = digits[i];
            }
        }

        // Display the largest and second largest digits
        if (largest != -1 && secondLargest != -1)
        {
            Console.WriteLine($"The largest digit is: {largest}");
            Console.WriteLine($"The second largest digit is: {secondLargest}");
        }
        else
        {
            Console.WriteLine("Not enough digits to determine the second largest.");
        }
    }
}
