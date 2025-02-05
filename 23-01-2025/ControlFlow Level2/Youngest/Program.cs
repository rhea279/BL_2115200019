using System;
class Youngest{
	static void Main(){
    	//Enter ages of Amar, Akbar, and Anthony
    	Console.Write("Enter Amar's Age:");
    	int ageAmar = Convert.ToInt32(Console.ReadLine());
    	Console.Write("Enter Akbar's Age:");
    	int ageAkbar = Convert.ToInt32(Console.ReadLine());
    	Console.Write("Enter Anthony's Age:");
    	int ageAnthoy = Convert.ToInt32(Console.ReadLine());
   	 
    	//Enter heights of Amar, Akbar, and Anthony
    	Console.Write("Enter Amar's Height (in cm):");
    	int heightAmar = Convert.ToInt32(Console.ReadLine());
    	Console.Write("Enter Akbar's Height (in cm):");
    	int heightAkbar = Convert.ToInt32(Console.ReadLine());
    	Console.Write("Enter Anthony's Height (in cm):");
    	int heightAnthoy = Convert.ToInt32(Console.ReadLine());
    	YoungestFrnd(ageAkbar,ageAmar,ageAnthoy);
    	TallestFrnd(heightAkbar,heightAmar,heightAnthoy);
   	 
	}
	//Find youngest among the three
	static void YoungestFrnd(int ageAkbar,int ageAmar, int ageAnthoy){
    	if(ageAkbar>ageAmar && ageAkbar>ageAnthoy){
        	Console.WriteLine("Akbar is the oldest");
    	}
    	else if(ageAmar>ageAkbar && ageAmar>ageAnthoy){
        	Console.WriteLine("Amar is the oldest");
    	}
    	else if(ageAnthoy>ageAkbar && ageAnthoy>ageAmar){
        	Console.WriteLine("Anthony is the oldest");
    	}
	}
	//find tallest among the three
	static void TallestFrnd(int heightAkbar,int heightAmar,int heightAnthoy){
    	if(heightAkbar>heightAmar && heightAkbar>heightAnthoy){
        	Console.WriteLine("Akbar is the tallest");
    	}
    	else if(heightAmar>heightAkbar && heightAmar>heightAnthoy){
        	Console.WriteLine("Amar is the tallest");
    	}
    	else if(heightAnthoy>heightAkbar && heightAnthoy>heightAmar){
        	Console.WriteLine("Anthony is the tallest");
    	}
	}
}

