using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main.Models;

public class SpendingAccount(string name) : IAccount
{
    public string Name { get; } = name;
    public AccountType AccountType { get; } = AccountType.Spending;
    public bool SmsNotification { get; set; } = false;

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