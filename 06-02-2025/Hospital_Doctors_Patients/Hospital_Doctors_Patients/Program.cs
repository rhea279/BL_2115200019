using System;
using System.Collections.Generic;

namespace Hospital_Doctors_Patients
{
    class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital("City Hospital");

            while (true) {
                Console.WriteLine("\n==== Hospital, Doctors, and Patients Model ====");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Add Patient");
                Console.WriteLine("3. Consult a Doctor");
                Console.WriteLine("4. Show All Doctors");
                Console.WriteLine("5. Show All Patients");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Choose an option:");
                int option;
                while(!int.TryParse(Console.ReadLine(), out option)||option < 1 || option > 6)
                {
                    Console.WriteLine("Invalid Option! Try again");
                }

                switch (option) {
                    case 1:
                        Console.Write("Enter Doctor Name: ");
                        string docName = Console.ReadLine();
                        Console.Write("Enter Doctor's Specialty: ");
                        string specialty = Console.ReadLine();
                        hospital.AddDoctor(new Doctor(docName, specialty));
                        Console.WriteLine($"Doctor '{docName}' added successfully!");
                        break;
                    case 2:
                        Console.Write("Enter Patient Name: ");
                        string patientName = Console.ReadLine();
                        Console.Write("Enter Patient Age: ");
                        int age;
                        while (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
                        {
                            Console.Write("Invalid age! Enter a valid number: ");
                        }
                        Console.Write("Enter Ailment: ");
                        string ailment = Console.ReadLine();
                        hospital.AddPatient(new Patient(patientName, age, ailment));
                        Console.WriteLine($"✅ Patient '{patientName}' added successfully!");
                        break;
                    case 3:
                        Console.Write("Enter Doctor's Name: ");
                        string doctorName = Console.ReadLine();
                        Console.Write("Enter Patient's Name: ");
                        string patientToConsult = Console.ReadLine();
                        hospital.ConsultDoctor(doctorName, patientToConsult);
                        break;

                    case 4:
                        hospital.ShowDoctors();
                        break;

                    case 5:
                        hospital.ShowPatients();
                        break;

                    case 6:
                        Console.WriteLine("Thank you for using the Hospital Management System! 👋");
                        return;
                }

            }
        }
    }
    class Hospital { 
        public string Name { get; private set; }
        private List<Patient> Patients;
        private List<Doctor> Doctors;

        public Hospital(string name) {
            Name = name; ;
            Patients = new List<Patient>();
            Doctors = new List<Doctor>();
        }

        public void AddDoctor(Doctor doctorName) { 
            Doctors.Add(doctorName);
        }

        public void AddPatient(Patient patientName)
        {
            Patients.Add(patientName);
        }

        public void ShowDoctors()
        {
            Console.WriteLine("\n Doctors in Hospital :");
            if (Doctors.Count == 0)
            {
                Console.WriteLine("No Doctors Available");
            }
            else
            {
                foreach (var doc in Doctors)
                {
                    Console.WriteLine($" - {doc.Name} (Speciality: {doc.Speciality}");
                }
            }
        }
        public void ShowPatients()
        {
            Console.WriteLine("\nPatients in Hospital :");
            if (Patients.Count == 0)
            {
                Console.WriteLine("No Patients Available");
            }
            else
            {
                foreach (var patient in Patients)
                {
                    Console.WriteLine($" - {patient.Name} (Ailment: {patient.Ailment}");
                }
            }
        }
        public void ConsultDoctor(string doctorName, string patientName)
        {
            Doctor doctor = Doctors.Find(d => d.Name.Equals(doctorName, StringComparison.OrdinalIgnoreCase));
            Patient patient = Patients.Find(p => p.Name.Equals(patientName, StringComparison.OrdinalIgnoreCase));

            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            doctor.Consult(patient);
        }
    }

    class Patient { 
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Ailment {  get; private set; }
    public Patient(string name, int age, string ailment)
        {
            Name = name;
            Age = age;
            Ailment = ailment;
        }
    }
    class Doctor
    {
        public string Name { get; private set; }
        public string Speciality { get; private set; }
        private List<Patient> patients;
        public Doctor(string name, string speciality)
        {
            Name = name;
            Speciality = speciality;
            patients = new List<Patient>();
        }

        public void Consult(Patient patient)
        {
            if (patients.Count == 0)
            {
                patients.Add(patient);
            }
            Console.WriteLine("\nConsultation Details: ");
            Console.WriteLine($"Dr.{Name} (Speciality: {Speciality}) is consulting {patient.Name} (Ailment:{patient.Ailment})"); 

        }

    }
}
