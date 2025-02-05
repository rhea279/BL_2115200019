using System;
class Employees{
	static void Main(){
    	//Input the number of years of service
    	Console.Write("Enter the number of years of service:");
    	int yrs = Convert.ToInt32(Console.ReadLine());
    	//Input the salary of employee
    	Console.Write("Enter the salary :");
    	double salary = Convert.ToDouble(Console.ReadLine());
    	Bonus(yrs,salary);
   	 
	}
	//Calculating Bonus amount
	static void Bonus(int yrs, double salary){
    	if(yrs>5){
        	double bonus =salary*0.05;
        	Console.WriteLine($"The bonus amount is: INR{bonus:F2}");
    	} else {
        	Console.WriteLine("The employee is not eligible for a bonus.");
    	}
	}
}