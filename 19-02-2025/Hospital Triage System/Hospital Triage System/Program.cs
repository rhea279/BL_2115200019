using System;
using System.Collections.Generic;

namespace HospitalTriage
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<Patient> triageQueue = new PriorityQueue<Patient>();

            Console.Write("Enter the number of patients: ");
            int numPatients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numPatients; i++)
            {
                Console.Write("Enter patient's name: ");
                string name = Console.ReadLine();

                Console.Write("Enter severity level (higher is more urgent): ");
                int severity = int.Parse(Console.ReadLine());

                triageQueue.Enqueue(new Patient(name, severity));
            }

            Console.WriteLine("\nTreatment Order:");
            while (triageQueue.Count > 0)
            {
                Patient patient = triageQueue.Dequeue();
                Console.WriteLine(patient.Name);
            }
        }
    }

    class Patient : IComparable<Patient>
    {
        public string Name { get; }
        public int Severity { get; }

        public Patient(string name, int severity)
        {
            Name = name;
            Severity = severity;
        }

        // Sorting in descending order (higher severity gets treated first)
        public int CompareTo(Patient other)
        {
            return other.Severity.CompareTo(this.Severity);
        }
    }

    class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> heap = new List<T>();

        public int Count => heap.Count;

        public void Enqueue(T item)
        {
            heap.Add(item);
            heap.Sort(); // Ensures highest priority is at the front
        }

        public T Dequeue()
        {
            if (heap.Count == 0) throw new InvalidOperationException("Queue is empty.");
            T top = heap[0];
            heap.RemoveAt(0);
            return top;
        }
    }
}
