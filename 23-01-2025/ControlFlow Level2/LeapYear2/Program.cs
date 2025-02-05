using System;

class LeapYear {
	static void Main() {
    	// Input the year from user
    	Console.WriteLine("Enter a year:");
    	int yr = Convert.ToInt32(Console.ReadLine());
    	CheckYear(yr);
	}

	// Check the conditions required for a leap year
	static void CheckYear(int year) {
    	if (year >= 1582) {
        	if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0)) {
            	Console.WriteLine($"{year} is a Leap Year.");
        	} else {
            	Console.WriteLine($"{year} is not a Leap Year.");
        	}
    	} else {
        	Console.WriteLine($"{year} is not a Leap Year.");
    	}
	}
}

