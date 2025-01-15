using System;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main;

namespace Boolean.CSharp.Main;

public class Account
{
    public readonly Guid accountId;
    public readonly string accountName;
    public readonly Guid userId;
    public BankBranch bankBranch;

    private decimal _accountBalance;
    private List<BankTransaction> _transactions;


    public Account(string accountName, Guid userId, BankBranch bankBranch)
    {
        this.accountId = Guid.NewGuid();
        this.accountName = accountName;
        this.userId = userId;
        this.bankBranch = bankBranch;
        this._accountBalance = 0;
        this._transactions = new List<BankTransaction>();
    }

    public decimal getAccountBalance()
    {
        return _transactions.Sum(t => t.transactionAmount);
    }

    public void deposit(decimal amount)
    {
        newTransaction(amount, TransactionTypes.Deposit);    
    }

    public void withdraw(decimal amount)
    {
        newTransaction(-amount, TransactionTypes.Withdrawal);
    }

    private void newTransaction(decimal amount, TransactionTypes transactionType)
    {
        var transaction = new BankTransaction(DateTime.Now, transactionType.ToString(), amount);


        if (transactionType == TransactionTypes.Withdrawal && getAccountBalance() < Math.Abs(amount))
        {
            var overdraftRequest = new OverdraftRequest(this.accountId, transaction);

            overdraftRequest.OverdraftApproved += OnOverdraftApproved;

            bankBranch.AddOverdraftRequest(overdraftRequest);
        }

        else
        {
            _transactions.Add(transaction);
        }
        
    }

    private void OnOverdraftApproved(OverdraftRequest request)
    {
        _transactions.Add(request.transaction);
    }
}
