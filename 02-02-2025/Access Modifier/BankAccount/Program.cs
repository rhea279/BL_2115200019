using System;
class BankAccount
{
    public int AccountNumber { get; set; }
    protected string AccountHolder { get; set; }
    private double Balance;

    public BankAccount(int accountNumber, string accountHolder, double balance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        Balance = balance;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient balance!");
        }
    }

    public double GetBalance()
    {
        return Balance;
    }
}

class SavingsAccount : BankAccount
{
    public SavingsAccount(int accountNumber, string accountHolder, double balance) : base(accountNumber, accountHolder, balance) {}

    public void DisplayDetails()
    {
        Console.WriteLine($"Savings Account - Account Number: {AccountNumber}, Account Holder: {AccountHolder}, Balance: {GetBalance()}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Account Number: ");
        int accountNumber = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Account Holder Name: ");
        string accountHolder = Console.ReadLine();
        Console.Write("Enter Initial Balance: ");
        double balance = Convert.ToDouble(Console.ReadLine());
        SavingsAccount savingsAccount = new SavingsAccount(accountNumber, accountHolder, balance);
        savingsAccount.DisplayDetails();
    }
}
