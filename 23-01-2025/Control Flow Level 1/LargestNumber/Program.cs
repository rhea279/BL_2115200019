using System;

class LargestNumber
{
	static void Main()
	{
    	// Input the three numbers
    	Console.Write("Enter the first number: ");
    	int number1 = int.Parse(Console.ReadLine());

    	Console.Write("Enter the second number: ");
    	int number2 = int.Parse(Console.ReadLine());

    	Console.Write("Enter the third number: ");
    	int number3 = int.Parse(Console.ReadLine());

    	// Check which number is the largest
    	bool isFirstLargest = number1 > number2 && number1 > number3;
    	bool isSecondLargest = number2 > number1 && number2 > number3;
    	bool isThirdLargest = number3 > number1 && number3 > number2;

    	// Output if each number is the largest
    	Console.WriteLine($"Is the first number the largest? {isFirstLargest}");
    	Console.WriteLine($"Is the second number the largest? {isSecondLargest}");
    	Console.WriteLine($"Is the third number the largest? {isThirdLargest}");

	}

    
}

