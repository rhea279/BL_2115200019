using System;

class CheckNum
{
    static void Main()
    {
        // Define an integer array of 5 elements
        int[] numbers = new int[5];

        // Get user input to store in array
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Enter {i + 1} number: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                numbers[i] = num;
                CheckingNum(num);
            }
            else
            {
                Console.WriteLine("Invalid Input. Please enter a valid integer.");
                i--; // Repeat the current iteration for valid input
            }
        }

        LargestElement(numbers);
    }
	//
    static void CheckingNum(int num)
    {
		//Check if the number Zero
        if (num == 0)
        {
            Console.WriteLine($"{num} is Zero.");
        }
		//If the number is positive, check for even or odd numbers
        else if (num > 0)
        {
            Console.WriteLine($"{num} is Positive.");
			if(num % 2 == 0){
				Console.WriteLine($"{num} is Even.");
			}
			else{
				Console.WriteLine($"{num} is Odd.");
			}
        }
		//Check if the number is negative
        else
        {
            Console.WriteLine($"{num} is Negative.");
        }
    }

    static void LargestElement(int[] number)
    {
        if (number[0] == number[4])
        {
            Console.WriteLine("First and Last Elements are equal.");
        }
        else if (number[0] > number[4])
        {
            Console.WriteLine("First Element is greater than Last Element.");
        }
        else
        {
            Console.WriteLine("Last Element is greater than First Element.");
        }
    }
}
