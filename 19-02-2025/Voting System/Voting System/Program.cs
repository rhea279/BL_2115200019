using System;
using System.Collections.Generic;
using System.Linq;

namespace VotingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> voteCounts = new Dictionary<string, int>();
            SortedDictionary<string, int> sortedResults;
            LinkedList<KeyValuePair<string, int>> voteOrder = new LinkedList<KeyValuePair<string, int>>();

            Console.Write("Enter the number of votes: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter candidate name: ");
                string candidate = Console.ReadLine();

                if (voteCounts.ContainsKey(candidate))
                {
                    voteCounts[candidate]++;
                }
                else
                {
                    voteCounts[candidate] = 1;
                }

                voteOrder.AddLast(new KeyValuePair<string, int>(candidate, voteCounts[candidate]));
            }

            sortedResults = new SortedDictionary<string, int>(voteCounts);

            Console.WriteLine("\nVote Counts (In Order of Votes Cast):");
            DisplayVotesInOrder(voteOrder);

            Console.WriteLine("\nSorted Results (Alphabetical Order):");
            DisplayVoteCounts(sortedResults);

            Console.WriteLine("\nWinner:");
            DisplayWinner(voteCounts);
        }

        static void DisplayVotesInOrder(LinkedList<KeyValuePair<string, int>> voteOrder)
        {
            foreach (var vote in voteOrder)
            {
                Console.WriteLine($"Candidate: {vote.Key}, Current Votes: {vote.Value}");
            }
        }

        static void DisplayVoteCounts(SortedDictionary<string, int> sortedResults)
        {
            foreach (var kvp in sortedResults)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} votes");
            }
        }

        static void DisplayWinner(Dictionary<string, int> voteCounts)
        {
            var winner = voteCounts.OrderByDescending(x => x.Value).First();
            Console.WriteLine($"{winner.Key} wins with {winner.Value} votes!");
        }
    }
}
