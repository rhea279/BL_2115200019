using System;
using System.Collections.Generic;

namespace Hospital_Patient_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nHospital Patient Management System:");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Display Patients");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Patient Type (InPatient/OutPatient): ");
                        string type = Console.ReadLine();

                        Console.Write("Enter Patient ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Age: ");
                        int age = int.Parse(Console.ReadLine());

                        if (type.Equals("InPatient", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Write("Enter Number of Days Admitted: ");
                            int days = int.Parse(Console.ReadLine());
                            patients.Add(new InPatient(id, name, age, days));
                        }
                        else if (type.Equals("OutPatient", StringComparison.OrdinalIgnoreCase))
                        {
                            patients.Add(new OutPatient(id, name, age));
                        }
                        else
                        {
                            Console.WriteLine("Invalid Patient Type!");
                        }
                        break;

                    case "2":
                        if (patients.Count == 0)
                        {
                            Console.WriteLine("No patients available.");
                        }
                        else
                        {
                            Console.WriteLine("\nPatient Details:");
                            foreach (var patient in patients)
                            {
                                patient.GetPatientDetails();
                            }
                        }
                        break;

                    case "3":
                        exit = true;
                        Console.WriteLine("Thank you for using Hospital Patient Management System!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please select again.");
                        break;
                }
            }
        }
    
    }
    //Implement an interface IMedicalRecord.
    interface IMedicalRecord
    {
        void AddRecord(string record);
        void ViewRecords();

    }
    //Create an abstract class Patient with fields: patientId, name, and age.
    abstract class Patient
    {
        private List<string> medicalRecords = new List<string>();
        public int patientID { get; private set; }
        public string name { get; set; }
        public int age { get; set; }
        public Patient(int PatientId, string Name, int Age)
        {
            patientID = PatientId;
            name = Name;
            age = Age;
        }
        //Add an abstract method CalculateBill().

        public abstract double CalculateBill();
        //Implement a concrete method GetPatientDetails()
        public void GetPatientDetails()
        {
            Console.WriteLine("/n==== Patient Details ====");
            Console.WriteLine($"Patient Id   : {patientID}");
            Console.WriteLine($"Patient Name : {name}");
            Console.WriteLine($"Patient Age  : {age}");
            Console.WriteLine($"Bill         : {CalculateBill()}INR");
        }
    }
    //Define subclass InPatient:Extend Patient into InPatient 
    class InPatient : Patient, IMedicalRecord
    {
        private double dailyCharge = 2000;
        private int daysAdmitted;
        private List<string> medicalRecords = new List<string>();

        public InPatient(int patientId, string name, int age, int daysAdmitted)
            : base(patientId, name, age)
        {
            this.daysAdmitted = daysAdmitted;
        }

        public override double CalculateBill()
        {
            return daysAdmitted * dailyCharge;
        }

        public void AddRecord(string record)
        {
            medicalRecords.Add(record);
        }

        public void ViewRecords()
        {
            Console.WriteLine("Medical Records:");
            foreach (var record in medicalRecords)
            {
                Console.WriteLine(record);
            }
        }

    }
    //Define subclass OutPatient:Extend Patient into OutPatient 
    class OutPatient : Patient {
        private double consultationFee = 500;
        private List<string> medicalRecords = new List<string>();

        public OutPatient(int patientId, string name, int age)
            : base(patientId, name, age) { }

        public override double CalculateBill()
        {
            return consultationFee;
        }

        public void AddRecord(string record)
        {
            medicalRecords.Add(record);
        }

        public void ViewRecords()
        {
            Console.WriteLine("Medical Records:");
            foreach (var record in medicalRecords)
            {
                Console.WriteLine(record);
            }
        }
    }
}
