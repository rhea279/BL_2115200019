using System;
using System.Collections.Generic;
using System.Linq;

class BankingSystem
{
    static Dictionary<int, double> accountBalances = new Dictionary<int, double>();
    static SortedDictionary<double, List<int>> sortedBalances = new SortedDictionary<double, List<int>>();
    static Queue<(int, double)> withdrawalQueue = new Queue<(int, double)>();

    static void Main()
    {
        Console.WriteLine("Enter the number of accounts:");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter Account ID: ");
            int accId = int.Parse(Console.ReadLine());

            Console.Write("Enter Initial Balance: ");
            double balance = double.Parse(Console.ReadLine());

            AddAccount(accId, balance);
        }

        // Asking for withdrawals
        Console.WriteLine("\nEnter the number of withdrawal requests:");
        int withdrawCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < withdrawCount; i++)
        {
            Console.Write("Enter Account ID for withdrawal: ");
            int accId = int.Parse(Console.ReadLine());

            Console.Write("Enter withdrawal amount: ");
            double amount = double.Parse(Console.ReadLine());

            RequestWithdrawal(accId, amount);
        }

        Console.WriteLine("\nProcessing withdrawals:");
        ProcessWithdrawals();

        Console.WriteLine("\nSorted Accounts by Balance:");
        DisplaySortedBalances();
    }

    static void AddAccount(int accId, double balance)
    {
        accountBalances[accId] = balance;

        if (!sortedBalances.ContainsKey(balance))
        {
            sortedBalances[balance] = new List<int>();
        }
        sortedBalances[balance].Add(accId);
    }

    static void RequestWithdrawal(int accId, double amount)
    {
        if (accountBalances.ContainsKey(accId) && accountBalances[accId] >= amount)
        {
            withdrawalQueue.Enqueue((accId, amount));
        }
        else
        {
            Console.WriteLine($"Withdrawal request failed for Account {accId}: Insufficient balance or invalid account.");
        }
    }

    static void ProcessWithdrawals()
    {
        while (withdrawalQueue.Count > 0)
        {
            var (accId, amount) = withdrawalQueue.Dequeue();
            if (accountBalances[accId] >= amount)
            {
                double oldBalance = accountBalances[accId];
                accountBalances[accId] -= amount;

                sortedBalances[oldBalance].Remove(accId);
                if (sortedBalances[oldBalance].Count == 0) sortedBalances.Remove(oldBalance);

                double newBalance = accountBalances[accId];
                if (!sortedBalances.ContainsKey(newBalance))
                {
                    sortedBalances[newBalance] = new List<int>();
                }
                sortedBalances[newBalance].Add(accId);

                Console.WriteLine($"Processed withdrawal of INR {amount} from Account {accId}. New Balance: INR {newBalance}");
            }
            else
            {
                Console.WriteLine($"Insufficient balance for Account {accId}. Withdrawal of INR {amount} denied.");
            }
        }
    }

    static void DisplaySortedBalances()
    {
        foreach (var entry in sortedBalances)
        {
            foreach (var accId in entry.Value)
            {
                Console.WriteLine($"Account {accId}: INR {entry.Key}");
            }
        }
    }
}
