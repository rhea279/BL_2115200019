using System;
using System.Collections.Generic;
namespace Banking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();
            while (true)
            {
                Console.WriteLine("\nBanking System:");
                Console.WriteLine("1. Open Account");
                Console.WriteLine("2. Display Accounts");
                Console.WriteLine("3. Deposit Money");
                Console.WriteLine("4. Withdraw Money");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Account Type (Savings/Current): ");
                        string type = Console.ReadLine();

                        Console.Write("Enter Account Number: ");
                        int number = int.Parse(Console.ReadLine());

                        Console.Write("Enter Holder Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Initial Balance: ");
                        double balance = double.Parse(Console.ReadLine());

                        if (type.Equals("Savings", StringComparison.OrdinalIgnoreCase))
                        {
                            accounts.Add(new SavingsAccount(number, name, balance));
                        }
                        else if (type.Equals("Current", StringComparison.OrdinalIgnoreCase))
                        {
                            accounts.Add(new CurrentAccount(number, name, balance));
                        }
                        else
                        {
                            Console.WriteLine("Invalid Account Type!");
                        }
                        break;

                    case "2":
                        if (accounts.Count == 0)
                        {
                            Console.WriteLine("No accounts available.");
                        }
                        else
                        {
                            Console.WriteLine("\nAccount Details:");
                            foreach (var account in accounts)
                            {
                                account.DisplayAccountDetails();
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Enter Account Number: ");
                        int depositAccount = int.Parse(Console.ReadLine());
                        BankAccount accDeposit = accounts.Find(a => a.accountNumber == depositAccount);
                        if (accDeposit != null)
                        {
                            Console.Write("Enter Amount to Deposit: ");
                            double depositAmount = double.Parse(Console.ReadLine());
                            accDeposit.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Account not found!");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Account Number: ");
                        int withdrawAccount = int.Parse(Console.ReadLine());
                        BankAccount accWithdraw = accounts.Find(a => a.accountNumber == withdrawAccount);
                        if (accWithdraw != null)
                        {
                            Console.Write("Enter Amount to Withdraw: ");
                            double withdrawAmount = double.Parse(Console.ReadLine());
                            accWithdraw.Withdraw(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Account not found!");
                        }
                        break;

                    case "5":

                        Console.WriteLine("Thank you for using Banking System!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Please select again.");
                        break;
                }
            }
        }
    }
    //Create an interface ILoanable with methods ApplyForLoan() and CalculateLoanEligibility()
    interface ILoanable
    {
        void ApplyForLoan();
        double CalculateLoanEligibility();
    }
    //Define abstract class BankAccount with fields like accountNumber, holderName, and balance
    abstract class BankAccount
    {
        public int accountNumber { get; private set; }
        public string holderName { get; private set; }
        public double balance { get; private set; }
        public BankAccount(int AccountNum, string HolderName, double Balance)
        {
            accountNumber = AccountNum;
            holderName = HolderName;
            balance = Balance;
        }
        public abstract double CalculateInterest();
        public void Deposit(double amount) {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited: {amount} \nNew Balance : {balance}");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount!");
            }
        }
        public void Withdraw(double amount) {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn: {amount}INR \nNew Balance: {balance}INR");
            }
            else
            {
                Console.WriteLine("Insufficient Funds");
            }
        }
        public void DisplayAccountDetails()
        {
            Console.WriteLine("\n==== Account Details ====");
            Console.WriteLine($"Account Number : {accountNumber}");
            Console.WriteLine($"Holder Name    : {holderName}");
            Console.WriteLine($"Balance        : {balance}");
            Console.WriteLine($"Interest Earned: {CalculateInterest()}");
        }

    }
    //Implement subclass SavingsAccount
    class SavingsAccount : BankAccount{
        private double interestRate = 0.04;
        public SavingsAccount(int AccountNum, string HolderName, double Balance)
            : base (AccountNum, HolderName, Balance) { }
        public override double CalculateInterest()
        {
            return balance * interestRate;
        }
    }
    //Implement subclass CurrentAccount
    class CurrentAccount : BankAccount , ILoanable{
        private double interestRate = 0.02;
        private double loanEligibilityFactor = 0.5;

        public CurrentAccount(int accountNumber, string holderName, double balance)
            : base(accountNumber, holderName, balance) { }

        public override double CalculateInterest()
        {
            return balance * interestRate;
        }

        public void ApplyForLoan()
        {
            Console.WriteLine("Loan application submitted for Current Account.");
        }

        public double CalculateLoanEligibility()
        {
            return balance * loanEligibilityFactor;
        }
    }
}
