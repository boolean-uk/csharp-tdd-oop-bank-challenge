using System;

namespace Boolean.CSharp.Main;

public class Account
{
    public readonly Guid accountId;
    public readonly string accountName;
    public readonly Guid userId;
    public readonly Guid bankBranchId;


    private decimal _accountBalance;
    private List<BankTransaction> _transactions;


    public Account(string accountName, Guid userId, Guid bankBranchId)
    {
        this.accountId = Guid.NewGuid();
        this.accountName = accountName;
        this.userId = userId;
        this.bankBranchId = bankBranchId;
        this._accountBalance = 0;
        this._transactions = new List<BankTransaction>();
    }

    public decimal getAccountBalance()
    {
        return _transactions.Sum(t => t.transactionAmount);
    }

    public void deposit(decimal amount)
    {
        this._transactions.Add(new BankTransaction(DateTime.Now, "Deposit", amount));

    }

    public void withdraw(decimal amount)
    {
        this._transactions.Add(new BankTransaction(DateTime.Now, "Withdraw", -amount));
    }
}
