using System;
using System.Collections.Generic;
namespace Bank_AccountHolders
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Bank
            Bank bank1 = new Bank("National Bank");

            // Create Customers
            Customer customer1 = new Customer("Alice");
            Customer customer2 = new Customer("Bob");

            // Open accounts for customers
            bank1.OpenAccount(customer1, "Savings", 1000);
            bank1.OpenAccount(customer1, "Checking", 500);
            bank1.OpenAccount(customer2, "Savings", 2000);

            // Customers check their balance
            customer1.ViewBalance();
            customer2.ViewBalance();
        }
    }

    //Bank class
    class Bank { 
        public string Name { get; set; }
        private List<Customer> customerList;

        public Bank(string name)
        {
            this.Name = name;
            customerList = new List<Customer>();
        }
        // Open a new account for a customer
        public void OpenAccount(Customer customer, string AccountType, double initialDeposit) {
            customerList.Add(customer);
            if (!customerList.Contains(customer)){
                customerList.Add(customer);
            }
            Console.WriteLine($"Account opened for {customer.Name} at {Name} with Balance {initialDeposit}");


        }
    }

    //Customer class
    class Customer {
        public string Name { get; set; }
        private List<BankAccount> bankAccountList;

        public Customer(string name) {
            Name = name;
            bankAccountList = new List<BankAccount>();
        }
        // Add a bank account
        public void AddAccount(BankAccount account) { 
            bankAccountList.Add(account);
        }

        // View balance of all accounts
        public void ViewBalance()
        {
            Console.WriteLine($"Customer : {Name}");
            foreach(var account in bankAccountList)
            {
                Console.WriteLine($"Bank : {account.Bank.Name} \nAccount Type: {account.AccountType} \nBalance :{account.Balance}");
            }
        }

    }

    class BankAccount { 
        public Bank Bank { get; set; }
        public string AccountType { get; set; }
        public double Balance { get; private set; }

        public BankAccount(Bank bank, string accountType, double initialDeposit ) {
            Bank = bank;
            AccountType = accountType;
            Balance = initialDeposit;
        }
    }

}
