using System;
class Calculator {
	static void Main(string[] args) {
    	// Input numbers and operator from user
    	Console.Write("Enter the first number: ");
    	double first = Convert.ToDouble(Console.ReadLine());

    	Console.Write("Enter the second number: ");
    	double second = Convert.ToDouble(Console.ReadLine());

    	Console.Write("Enter the operator (+, -, *, /): ");
    	string op = Console.ReadLine();

    	// Perform calculation based on operator
    	switch (op) {
        	case "+":
            	Console.WriteLine($"Result: {first} + {second} = {first + second}");
            	break;
        	case "-":
            	Console.WriteLine($"Result: {first} - {second} = {first - second}");
            	break;
        	case "*":
            	Console.WriteLine($"Result: {first} * {second} = {first * second}");
            	break;
        	case "/":
            	if (second != 0) {
                	Console.WriteLine($"Result: {first} / {second} = {first / second}");
            	} else {
                	Console.WriteLine("Error: Division by zero is not allowed.");
            	}
            	break;
        	default:
            	Console.WriteLine("Invalid Operator.");
            	break;
    	}
	}
}