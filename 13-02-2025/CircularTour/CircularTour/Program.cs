using System;
using System.Collections.Generic;


namespace CircularTour
{
    class CircularTour
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of petrol pumps:");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] petrol = new int[n];
            int[] distance = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter petrol available at pump {i + 1}:");
                petrol[i] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Enter distance to next pump from pump {i + 1}:");
                distance[i] = Convert.ToInt32(Console.ReadLine());
            }

            int start = FindStartingPump(petrol, distance);
            if (start == -1)
                Console.WriteLine("No valid starting point for circular tour.");
            else
                Console.WriteLine($"Start at petrol pump index: {start}");
        }
        public static int FindStartingPump(int[] petrol, int[] distance)
        {
            int n = petrol.Length;
            int totalSurplus = 0;
            Queue<int> queue = new Queue<int>();//Store pump indices
            int currentSurplus = 0;
            int startIndex = 0;

            for (int i = 0; i < n; i++)
            {
                int diff = petrol[i] - distance[i];
                totalSurplus += diff;
                currentSurplus += diff;
                queue.Enqueue(i);

                while(currentSurplus < 0 && queue.Count > 0)
                {
                    startIndex= queue.Dequeue()+1;
                    currentSurplus = 0;
                }
            }
            return (totalSurplus >= 0) ? startIndex : -1;
        }
    }
}
