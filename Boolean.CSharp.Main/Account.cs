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
    public List<BankTransaction> transactions { get; private set; }


    public Account(string accountName, Guid userId, BankBranch bankBranch)
    {
        this.accountId = Guid.NewGuid();
        this.accountName = accountName;
        this.userId = userId;
        this.bankBranch = bankBranch;
        this.transactions = new List<BankTransaction>();
    }

    public decimal getAccountBalance()
    {
        return transactions.Sum(t => t.transactionAmount);
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
        var transaction = new BankTransaction(DateTime.Now, transactionType, amount, getAccountBalance());


        if (transactionType == TransactionTypes.Withdrawal && getAccountBalance() < Math.Abs(amount))
        {
            var overdraftRequest = new OverdraftRequest(this.accountId, transaction);

            overdraftRequest.OverdraftApproved += OnOverdraftApproved;

            bankBranch.AddOverdraftRequest(overdraftRequest);
        }

        else
        {
            transactions.Add(transaction);
        }
        
    }

    private void OnOverdraftApproved(OverdraftRequest request)
    {
        transactions.Add(request.transaction);
    }
}
