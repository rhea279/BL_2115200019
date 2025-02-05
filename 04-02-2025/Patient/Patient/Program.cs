using System;
using System.Collections.Generic;

namespace Patient
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient.hospitalName = "City Hospital";
            Console.WriteLine("Welcome to City Hospital !");
            //List to store all patients
            List<Patient> patients = new List<Patient>();
            while (true)
            {
                //Display Menu Options
                Console.WriteLine("\n ==== Hospital Management System ====");
                Console.WriteLine("1. Enroll New Patient ");
                Console.WriteLine("2. Display Patient Details");
                Console.WriteLine("3. Show Total Patients");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose an option : ");

                int choice;
                //Input validation: Ensure choice is between 1 and 4
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid Option! Enter a valid option (1 - 4):");
                }

                switch (choice)
                {
                    case 1:
                        // Enroll New Patient
                        Console.WriteLine("Enter Details of New Patient");
                        Console.WriteLine("Enter Patient's Name : ");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter Patient's Age : ");
                        int age = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Patient's Ailment : ");
                        string ailment = Console.ReadLine();

                        Console.WriteLine("Enter Patient Id : ");
                        int patientId;
                        while (!int.TryParse(Console.ReadLine(), out patientId) || patientId <= 0)
                        {
                            Console.Write("Invalid Patient Id! Enter a valid number: ");
                        }

                        // Create a new Patient object and add it to the list
                        patients.Add(new Patient(name, age, ailment, patientId));

                        Console.WriteLine("New Registration Completed!");
                        break;
                    case 2:
                        // Display Patient Details
                        Console.WriteLine("Enter Patient Id to View Details :");
                        int searchNum;
                        while (!int.TryParse(Console.ReadLine(), out searchNum))
                        {
                            Console.WriteLine("Enter Valid Number");
                        }
                        // Find Patient by Patient Id
                        Patient patient = patients.Find(p => p.patientID == searchNum);
                        if (patient != null)
                        {
                            // Use is operator to check if object is a Patient instance
                            if (patient is Patient)
                            {
                                patient.DisplayPatientDetails();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Patient Not Found!");
                        }
                        break;
                    case 3:
                        // Show Total Patients
                        Console.WriteLine($" Total Patients in the Hospital: {Patient.GetTotalPatients()}");
                        break;
                    case 4:
                        // Exit Program
                        Console.WriteLine("Thank you for using Hospital Management System!");
                            return;

                }
            }
        }
    }
    class Patient {
            public static string hospitalName = "Default Name";
            // Static variable to count total patients
            private static int totalPatients = 0;

            // Readonly Patient ID (unique for each patient)
            public readonly int patientID;

            // Instance variables for patient details
            public string name { get; private set; }
            public int age { get; private set; }
            public string ailment { get; private set; }
            public Patient(string Name,int Age, string Ailment,int id) {
                this.name = Name;
                this.age = Age; 
                this.ailment = Ailment;
                this.patientID = id;
                totalPatients++;
            }

        // Method to display patient details
        public void DisplayPatientDetails(){
                Console.WriteLine("==== Patient Details ====");
                Console.WriteLine($"Patient Name      	: {name}");
                Console.WriteLine($"Patient Age     	: {age}");
                Console.WriteLine($"Patient Ailment     : {ailment}");
                Console.WriteLine($"Patient Id      	: {patientID}");

            }

        // Static method to display total patients
        public static int GetTotalPatients() { 
                return totalPatients;
            }
    }
}
