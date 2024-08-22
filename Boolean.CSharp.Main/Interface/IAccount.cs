using Boolean.CSharp.Main.Models;

namespace Boolean.CSharp.Main.Interface;

public interface IAccount
{
    public string Name { get; }
    public AccountType AccountType { get; }
    public bool SmsNotification { get; set; }
    public List<BankTransaction> GetTransactions();
    public void PrintTransactions();
    public decimal Deposit(decimal amount);
    public decimal Withdraw(decimal amount);
    public decimal GetBalance();
    public void ToggleSmsNotification();
}

public enum AccountType
{
    Spending,
    Saving,
    Credit
}