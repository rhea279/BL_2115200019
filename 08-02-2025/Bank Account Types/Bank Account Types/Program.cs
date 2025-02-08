using System;

namespace Bank_Account_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt user for account details
            Console.Write("Enter Account Number: ");
            int accountNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Initial Balance: ");
            double balance = double.Parse(Console.ReadLine());

            Console.Write("Enter Account Type (Savings/Checking/FixedDeposit): ");
            string accountType = Console.ReadLine().ToLower();

            BankAccount account;

            if (accountType == "savings")
            {
                Console.Write("Enter Interest Rate: ");
                double interestRate = double.Parse(Console.ReadLine());
                account = new SavingsAccount(accountNumber, balance, interestRate);
            }
            else if (accountType == "checking")
            {
                Console.Write("Enter Withdrawal Limit: ");
                double withdrawalLimit = double.Parse(Console.ReadLine());
                account = new CheckingAccount(accountNumber, balance, withdrawalLimit);
            }
            else if (accountType == "fixeddeposit")
            {
                Console.Write("Enter Maturity Period (in months): ");
                int maturityPeriod = int.Parse(Console.ReadLine());
                account = new FixedDepositAccount(accountNumber, balance, maturityPeriod);
            }
            else
            {
                Console.WriteLine("Invalid account type!");
                return;
            }

            Console.WriteLine("\nAccount Information:");
            account.DisplayAccountType();
        
    }
    }
    //Define a base class BankAccount
    class BankAccount
    {
        public int AccountNumber { get; private set; }
        public double Balance { get; private set; }
        public BankAccount(int accountNumber, double balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }
        public virtual void DisplayAccountType()
        {
            Console.WriteLine("General Bank Account");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: ${Balance}");
        }
    }
    //Define a subclass SavingsAccount
    class SavingsAccount : BankAccount {
        public double InterestRate {  get; private set; }
        public SavingsAccount(int accountNumber, double balance, double interestRate)
            : base(accountNumber, balance) {
            InterestRate = interestRate; 
        }
        public override void DisplayAccountType()
        {
            base.DisplayAccountType();
            Console.WriteLine("Account Type: Savings");
            Console.WriteLine($"Interest Rate: {InterestRate}%");
        }
    }
    //Define a subclass CheckingAccount
    class CheckingAccount : BankAccount
    {
        public double WithdrawalLimit { get; private set; }
        public CheckingAccount(int accountNumber, double balance, double withdrawalLimit)
            : base(accountNumber, balance)
        {
            WithdrawalLimit = withdrawalLimit;
        }

        public override void DisplayAccountType()
        {
            base.DisplayAccountType();
            Console.WriteLine("Account Type: Checking");
            Console.WriteLine($"Withdrawal Limit: ${WithdrawalLimit}");
        }
    }
    //Define a subclass FixedDepositAccount
    class FixedDepositAccount : BankAccount {
        public int MaturityPeriod { get; set; }

        public FixedDepositAccount(int accountNumber, double balance, int maturityPeriod)
            : base(accountNumber, balance)
        {
            MaturityPeriod = maturityPeriod;
        }

        public override void DisplayAccountType()
        {
            base.DisplayAccountType();
            Console.WriteLine("Account Type: Fixed Deposit");
            Console.WriteLine($"Maturity Period: {MaturityPeriod} months");
        }
    }

}
