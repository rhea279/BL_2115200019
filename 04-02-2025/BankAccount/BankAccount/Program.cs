using System;
namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount.bankName = "SBI Bank";
            Console.WriteLine("Welcome to SBI Bank ATM !");

            Console.WriteLine("Enter Account Holder Name:");
            string name = Console.ReadLine(); 
            Console.WriteLine("Enter Account Number:");
            int accNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Initial Balance:");
            double initialBalance = Convert.ToDouble(Console.ReadLine());
            
            BankAccount acc1 = new BankAccount(name, accNum,initialBalance);

            
                Console.WriteLine("\n ==== ATM OPERATIONS ====");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Display Account Details");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an option : ");

            
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5) {
                Console.WriteLine("Invalid Option! Enter a valid option (1 - 5):");  
            }
            switch (choice) {
                case 1:
                    Console.WriteLine("Enter deposit amount :");
                    double depositAmount;
                    while (!double.TryParse(Console.ReadLine(), out depositAmount)||depositAmount <= 0)
                    {
                        Console.WriteLine("Invalid Amount! Enter correct amount again:");
                    }
                    acc1.Deposit(depositAmount);
                    break;
                case 2:
                    Console.WriteLine("Enter Withdraw Amount :");
                    double withdrawAmount;
                    while(!double.TryParse(Console.ReadLine(), out withdrawAmount)||withdrawAmount > initialBalance || withdrawAmount <= 0){
                        Console.WriteLine("Invalid Amount! Try Again :");
                    }
                    acc1.Withdraw(withdrawAmount);
                    break;
                case 3:
                    acc1.CheckBalance();
                    break;
                case 4:
                    acc1.DisplayAccountDetails();
                    break;
                case 5:
                    Console.WriteLine("\nThank You for using SBI Bank ATm. Goodbye !");
                    return;
            }
            

            Console.WriteLine("Total Accounts : " + BankAccount.GetTotalAccounts());
        }
    }
    class BankAccount
    {
        //A static variable bankName shared across all accounts.
        public static string bankName = "Default Bank";
        private static int totalAccounts = 0;

        public string AccountHolderName;
        //Use a readonly variable AccountNumber to ensure it cannot be changed once assigned.
        public readonly int AccountNumber;
        public double InitialBalance;

        //resolve ambiguity in the constructor when initializing AccountHolderName and AccountNumber.
        public BankAccount(string AccountHolderName, int AccountNumber, double initialBalance)
        {
            this.AccountHolderName = AccountHolderName;
            this.AccountNumber = AccountNumber;
            totalAccounts++;
            this.InitialBalance = initialBalance;
        }
        //A static method to display the total number of accounts.
        public static int GetTotalAccounts()
        {
            return totalAccounts;

        }
        //Check if an account object is an instance of the BankAccount class before displaying its details.
        public void DisplayAccountDetails()
        {
            if (this is BankAccount)
            {
                Console.WriteLine($"Bank Name : {bankName}");
                Console.WriteLine($"Account Holder : {AccountHolderName}");
                Console.WriteLine($"Account Number : {AccountNumber}");
                Console.WriteLine($"Initial Balance : {InitialBalance}");
            }
        }
        public void Deposit(double depositAmount)
        {
            InitialBalance += depositAmount;
            Console.WriteLine($"\n{AccountHolderName} deposited {depositAmount} INR");
            CheckBalance();
        }
        public void Withdraw(double withdrawAmount) { 
            InitialBalance -= withdrawAmount;
            Console.WriteLine($"\n{AccountHolderName} withdrew {withdrawAmount} INR.");
            CheckBalance();
        }
        public void CheckBalance()
        {
            Console.WriteLine($"Current BAlance of Acc/No {AccountNumber} : {InitialBalance}INR");
        }
    }
}
