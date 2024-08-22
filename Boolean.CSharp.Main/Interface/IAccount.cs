using Boolean.CSharp.Main.Models;

namespace Boolean.CSharp.Main.Interface;

public interface IAccount
{
    public List<BankTransaction> GetTransactions();
    public void PrintTransactions();
    public decimal Deposit(decimal amount);
    public decimal Withdraw(decimal amount);
    public decimal GetBalance();
}

public enum AccountType
{
    SPENDING,
    SAVING,
    CREDIT
}