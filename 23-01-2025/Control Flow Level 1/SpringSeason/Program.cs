using System;
class SpringSeason {
	static void Main(){
    	//Input the Day from the User
    	Console.Write("Enter the day :");
    	int day = Convert.ToInt32(Console.ReadLine());
   	 
    	//Input the Month from the User
    	Console.Write("Enter the month :");
    	int month = Convert.ToInt32(Console.ReadLine());
    	//Output after checking the date
    	if(CheckSpring(day,month)){
        	Console.WriteLine("It's a Spring season.");
    	}else{
        	Console.WriteLine("Not a Spring season.");
    	}
   	 
	}
	//Checking if the Date is in Spring Season or not
	static bool CheckSpring(int day, int month){
    	if(month == 3 && day >=20 && day <=31 ){return true;} //For the month of March
    	if(month == 4 && day >=1 && day <=30 ){return true;}  //For the month of April
    	if(month == 5 && day >=1 && day <=31 ){return true;}  //For the month of May
    	if(month == 6 && day >=1 && day <=20 ){return true;}  //For the month of June
    	else {
        	return false;
    	}
	}
}

