using System;
using System.Collections.Generic;
namespace Vehicle
{
    class Program
    {
        static void Main(string[] args)
        {
            //List to store all registered vehicles
            List<Vehicle> vehicles = new List<Vehicle>();
            while (true) {
                //Display Menu Options
                Console.WriteLine("\n ==== Vehicle Registration System ====");
                Console.WriteLine("1. Enroll New Vehicle Registration ");
                Console.WriteLine("2. Display Vehicle Registration Details");
                Console.WriteLine("3. Update Registration Fee");
                Console.WriteLine("4. Show Total Registration");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an option : ");

                int choice;
                //Input validation: Ensure choice is between 1 and 5
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid Option! Enter a valid option (1 - 5):");
                }

                switch (choice) {
                    case 1:// Enroll New Vehicle

                        Console.WriteLine("Enter Details of New Vehicle");
                        Console.WriteLine("Enter Owner Name : ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Vehicle Type : ");
                        string vehicleType = Console.ReadLine();
                        Console.WriteLine("Enter Registration Number : ");
                        int registrationNum;
                        while (!int.TryParse(Console.ReadLine(), out registrationNum) || registrationNum <= 0)
                        {
                            Console.Write("Invalid Registration Number! Enter a valid number: ");
                        }
                        // Create a new Vehicle object and add it to the list
                        vehicles.Add(new Vehicle(name,vehicleType,registrationNum));

                        Console.WriteLine("New Registration Completed!");
                        break;

                    case 2:
                        // Display Registration Details
                        Console.WriteLine("Enter Vehicle Regestration Number to View Details :");
                        int searchNum;
                        while (!int.TryParse(Console.ReadLine(),out searchNum)){
                            Console.WriteLine("Enter Valid Number");
                        }
                        // Find vehicle by registration number
                        Vehicle vehicle = vehicles.Find(v=>v.registrationNumber == searchNum);
                        if(vehicle != null)
                        {
                            vehicle.DisplayRegistrationDetails();
                        }
                        else
                        {
                            Console.WriteLine("Enter Valid Number!");
                        }
                        break;
                    case 3:
                        // Update Registration Fee
                        Console.WriteLine("Enter Roll Number to Update Grade :");
                        int updateNum;
                        while (!int.TryParse(Console.ReadLine(), out updateNum))
                        {
                            Console.WriteLine("Enter a Valid Roll Number!");
                        }
                        Vehicle foundVehicle = vehicles.Find(s => s.registrationNumber == updateNum);
                        if (foundVehicle != null)
                        {
                            Console.Write("Enter New Registration Fee : ");
                            int newFee = Convert.ToInt32(Console.ReadLine());
                            Vehicle.UpdateRegistrationFee(newFee);
                        }
                        else
                        {
                            Console.WriteLine("Vehicle Not Found");
                        }
                        break;
                    case 4:
                        // Show Total Registrations
                        Vehicle.DisplayTotalRegistrations();
                        break;
                    case 5:
                        // Exit Program
                        Console.WriteLine("\nThank you for using Vehicle Registration System!");
                        return;


                }


            }
        }
    }
    class Vehicle {
        // Static variable to store the registration fee (common for all vehicles)
        public static int registrationFee = 1000;
        // Readonly variable to store a unique registration number
        public readonly int registrationNumber;


        // Instance variables for owner name and vehicle type
        public string ownerName;
        public string vehicleType;

        // Static variable to count total registrations
        private static int totalRegistrations = 0;

        // Constructor to initialize vehicle details
        public Vehicle(string OwnerName, string VehicleType, int RegistrationNumber) { 
            this.registrationNumber = RegistrationNumber;
            this.ownerName = OwnerName;
            this.vehicleType = VehicleType;
            totalRegistrations++;

        }

        // Method to display vehicle registration details
        public void DisplayRegistrationDetails()
        {
            Console.WriteLine("==== Registration Details ====");
            Console.WriteLine($"Owner Name          : {ownerName}");
            Console.WriteLine($"Vehicle Type        : {vehicleType}");
            Console.WriteLine($"Registration Number : {registrationNumber}");
            Console.WriteLine($"Registration Fee    : {registrationFee}");
        }

        // Static method to update the registration fee
        public static void UpdateRegistrationFee(int newFee) {
                registrationFee = newFee;
                Console.WriteLine("Registration Fee Updated!");
        }

        // Static method to display total registrations
        public static void DisplayTotalRegistrations() {
            Console.WriteLine($"Total Registrations : {totalRegistrations}");
        }
    }
}
