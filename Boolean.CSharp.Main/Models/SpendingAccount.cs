using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main.Models;

public class SpendingAccount : IAccount
{
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
}