using System;

namespace Restaurant_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt user for worker details
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Role (Chef/Waiter): ");
            string role = Console.ReadLine().ToLower();

            Person person;

            if (role == "chef")
            {
                Console.Write("Enter Specialty: ");
                string specialty = Console.ReadLine();
                person = new Chef(name, id, specialty);
            }
            else if (role == "waiter")
            {
                Console.Write("Enter Experience (years): ");
                int experience = int.Parse(Console.ReadLine());
                person = new Waiter(name, id, experience);
            }
            else
            {
                Console.WriteLine("Invalid role!");
                return;
            }

            Console.WriteLine("\nWorker Information:");
            person.DisplayInfo();
            ((Worker)person).PerformDuties();
        }
    }

    // Superclass representing a person
    class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Person(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {Id}");
        }
    }

    // Interface defining worker duties
    interface Worker
    {
        void PerformDuties();
    }

    // Chef subclass
    class Chef : Person, Worker
    {
        public string Specialty { get; set; }

        public Chef(string name, int id, string specialty)
            : base(name, id)
        {
            Specialty = specialty;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Role: Chef");
            Console.WriteLine($"Specialty: {Specialty}");
        }

        public void PerformDuties()
        {
            Console.WriteLine("Duties: Prepares meals and ensures kitchen efficiency.");
        }
    }

    // Waiter subclass
    class Waiter : Person, Worker
    {
        public int Experience { get; set; }

        public Waiter(string name, int id, int experience)
            : base(name, id)
        {
            Experience = experience;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Role: Waiter");
            Console.WriteLine($"Experience: {Experience} years");
        }

        public void PerformDuties()
        {
            Console.WriteLine("Duties: Serves customers and ensures excellent service.");
        }
    }
}
