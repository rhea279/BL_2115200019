
using System;

namespace Bank_Transaction_System
{
    class InsufficientFundsException : Exception
    {
        public double Amount { get; }
        public InsufficientFundsException(string message, double amount) : base(message)
        {
            Amount = amount;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        
    }
    class BankAccount
    {
        private double balance;
        public BankAccount(double initialBalance)
        {
            balance = initialBalance;
        }
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
        }
        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new InsufficientFundsException("Insufficient funds for withdrawal", amount - balance);
            }
            balance -= amount;
        }
        public double GetBalance() => balance;
        static void Main()
        {
            BankAccount account = new BankAccount(0);

            try
            {
                Console.WriteLine("Enter Deposit Amount:");
                double amount = Convert.ToDouble(account.GetBalance());
                account.Deposit(amount);
                Console.WriteLine("New balance: INR" + account.GetBalance());

                Console.WriteLine("Enter withdraw amount:");
                double withdraw = Convert.ToDouble(account.GetBalance());
                account.Withdraw(withdraw);
            }
            catch (InsufficientFundsException e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                Console.WriteLine($"Shortfall: INR{e.Amount}");
            }
        }

    }
