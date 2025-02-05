using System;

class DayOfWeek{
	static void Main(string[] args) {
    	// Input the date components from user
    	Console.Write("Enter month (1-12): ");
    	int m = Convert.ToInt32(Console.ReadLine());

    	Console.Write("Enter day (1-31): ");
    	int d = Convert.ToInt32(Console.ReadLine());

    	Console.Write("Enter year: ");
    	int y = Convert.ToInt32(Console.ReadLine());

    	// Calculate the day of the week
    	int dayOfWeek = CalculateDayOfWeek(m, d, y);

    	// Output the day of the week
    	Console.WriteLine($"The day of the week is: {dayOfWeek}");
	}

	static int CalculateDayOfWeek(int m, int d, int y) {
    	// Adjustments for Gregorian calendar
    	int y0 = y - (14 - m) / 12;
    	int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
    	int m0 = m + 12 * ((14 - m) / 12) - 2;
    	int d0 = (d + x + 31 * m0 / 12) % 7;

    	return d0;
    	}
}

