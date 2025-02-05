using System;
class BMI{
	static void Main(){
    	//Input the Weight from User
    	Console.Write("Enter Weight(in kg) :");
    	double weight = Convert.ToDouble(Console.ReadLine());
    	//Input the Height from User
    	Console.Write("Enter Height(in cm) :");
    	double heightCm = Convert.ToDouble(Console.ReadLine());

    	// Convert height from centimeters to meters
    	double heightMeters = heightCm / 100;
    	double bmi = weight / (heightMeters * heightMeters);
    	Status(bmi);
	}
	static void Status(double bmi){
    	if(bmi <= 18.4){
        	Console.Write("Underweight");
    	}else if(bmi >= 18.5 && bmi <= 24.9){
        	Console.Write("Normal");
    	}
    	else if(bmi >=25.0 && bmi<=39.9 ){
        	Console.Write("Overweight");
    	}
    	else if(bmi >= 40.0){
        	Console.Write("Obese");
    	}
	}
}

