using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Round_Robin_Scheduling_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Processing processQueue = new Processing();
            Console.Write("Enter the time quantum: ");
            int timeQuantum = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("\n--- Round Robin Scheduling ---");
                Console.WriteLine("1. Add a Process");
                Console.WriteLine("2. Execute Processes (Simulate Scheduling)");
                Console.WriteLine("3. Display Process Queue");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Process ID: ");
                        int processId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Burst Time: ");
                        int burstTime = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Priority: ");
                        int priority = Convert.ToInt32(Console.ReadLine());
                        processQueue.AddAtEnd(processId, burstTime, priority);
                        break;
                    case 2:
                        processQueue.ExecuteProcesses(timeQuantum);
                        break;
                    case 3:
                        processQueue.DisplayProcess();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
    class Process
    {
        public int ProcessId { get; set; }
        public int BurstTime { get; set; }
        public int RemainingTime {  get; set; }
        public int Priority { get; set; }
        public int WaitingTime {  get; set; }
        public int TurnAroundTime {  get; set; }

        public Process Next;
        public Process(int processId, int burstTime, int priority)
        {
            ProcessId = processId;
            BurstTime = burstTime;
            Priority = priority;
            RemainingTime = burstTime;
            Next = this;
        }
    }
    class Processing
    {
        private Process head = null;
        private Process tail = null;
        //Add a new process at the end of the circular list
        public void AddAtEnd(int processId, int burstTime, int priority)
        {
            Process newProcess = new Process(processId, burstTime, priority);
            if (head == null)
            {
                head = tail = newProcess;
                tail.Next = head;
            }
            else
            {
               
                tail.Next = newProcess;
                newProcess.Next = head;
                tail = newProcess;
            }
            Console.WriteLine($"Process {processId} added successfully.");
        }
        //Remove a process by Process ID after its execution
        public void RemoveProcess(int processId)
        {
            if (head == null)
            {
                return;
            }
            Process current = head;
            Process prev = null;
            do
            {
                if (current.ProcessId == processId)
                {
                    if (current == head && current == tail)
                    {
                        head = tail = null;

                    }
                    else if (current == head)
                    {
                        head = head.Next;
                        tail.Next = head;
                    }
                    else if (current == tail)
                    {
                        prev.Next = head;
                        tail = prev;
                    }
                    else
                    {
                        prev.Next = current.Next;
                    }
                    Console.WriteLine($"Process {processId} is successfully removed.");
                    return;
                }
                prev = current;
                current = current.Next;
            }
            while (current != head);
            Console.WriteLine("Process Not found");

        }
        //Simulate the scheduling of processes in a round-robin manner with a fixed time quantum
        public void ExecuteProcesses(int timeQuantum)
        {
            if(head == null)
            {
                Console.WriteLine("No process to execute");
                return;
            }
            int totalWaitingTime = 0;
            int totalTurnAroundTime = 0;
            int processCount = 0;
            int elapsedTime = 0;
            while (head != null)
            {
                Process current = head;
                do
                {
                    if (current.RemainingTime > 0)
                    {
                        Console.WriteLine($"\nExecuting Process {current.ProcessId}");
                        int executionTime = Math.Min(current.RemainingTime, timeQuantum); ;
                        current.RemainingTime -= executionTime;
                        elapsedTime += executionTime;

                        if (current.RemainingTime == 0)//Process is finished
                        {
                            current.TurnAroundTime = elapsedTime;
                            current.WaitingTime = current.TurnAroundTime - current.BurstTime;
                            totalWaitingTime += current.WaitingTime;
                            totalTurnAroundTime += current.TurnAroundTime;
                            processCount++;

                            //Remove the process after execution
                            int processIdToRemove = current.ProcessId;
                            current = current.Next;
                            RemoveProcess(processIdToRemove);
                            continue;
                        }
                    }
                    current = current.Next;
                } while (current != null);
            }
            //Calculate and display the average waiting time and turn-around time for all processes.
            if (processCount > 0)
            {
                Console.WriteLine($"\nAverage Waiting Time : {(double)totalWaitingTime / processCount:F2}");
                Console.WriteLine($"\nAverage Turn-Around Time : {(double)totalTurnAroundTime / processCount:F2}");
            }
        }
        //Display the list of processes in the circular queue after each round
        public void DisplayProcess()
        {
            if(head == null)
            {
                Console.WriteLine("No process in queue");
                return;
            }

            Process temp = head;
            Console.WriteLine("\nProcesses in Queue:");
            do
            {
                Console.WriteLine($"Process ID: {temp.ProcessId}, Burst Time: {temp.BurstTime}, Remaining Time: {temp.RemainingTime}, Priority: {temp.Priority}");
                temp = temp.Next;
            } while (temp != head);
        }

    }
}



