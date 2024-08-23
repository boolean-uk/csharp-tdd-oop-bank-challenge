using System.Transactions;

namespace Boolean.CSharp.Main.Models.Accounts;

public class Account(string name, AccountType type)
{
    public string Name { get; } = name;
    public AccountType AccountType { get; } = type;
    public bool SmsNotification { get; set; } = false;
    private List<Transaction> Transactions { get; set; } = new();
    
    public List<BankTransaction> GetTransactions()
    {
        throw new NotImplementedException();
    }

    public void PrintTransactions()
    {
        throw new NotImplementedException();
    }

    public decimal Deposit(decimal amount)
    {
        throw new NotImplementedException();
    }

    public decimal Withdraw(decimal amount)
    {
        throw new NotImplementedException();
    }

    public decimal GetBalance()
    {
        throw new NotImplementedException();
    }

    public void ToggleSmsNotification()
    {
        SmsNotification = !SmsNotification;
    }
}

public enum AccountType
{
    Spending,
    Saving,
    Credit
}