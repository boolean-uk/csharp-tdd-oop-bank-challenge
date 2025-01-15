using System.Diagnostics.CodeAnalysis;

namespace Boolean.CSharp.Main;

public enum TransactionType
{
    Deposit,
    Withdrawal,
}

public class Transaction
{
    public decimal Amount { get; init; }
    public TransactionType Type { get; init; }
    public DateTime TransactionDate { get; init; }

    public Transaction(decimal amount, TransactionType transactionType)
    {
        this.Amount = amount;
        this.Type = transactionType;
        this.TransactionDate = DateTime.Now;
    }

    public decimal ToValue()
    {
        if (this.Type == TransactionType.Withdrawal)
        {
            return -Amount;
        }
        else
        {
            return Amount;
        }
    }

    public static Transaction Withdraw(decimal amount)
    {
        return new Transaction(amount, TransactionType.Withdrawal);
    }

    public static Transaction Deposit(decimal amount)
    {
        return new Transaction(amount, TransactionType.Deposit);
    }
}

public class TransactionLogField
{
    public required Transaction transaction { get; init; }
    public required decimal currentBalance { get; init; }

    [SetsRequiredMembers]
    public TransactionLogField(Transaction transaction, decimal currentBalance)
    {
        this.transaction = transaction;
        this.currentBalance = currentBalance;
    }

    public override string ToString()
    {
        if (transaction.Type == TransactionType.Deposit)
        {
            return $"{transaction.TransactionDate.ToShortDateString(), -11}|| {transaction.Amount, -9} || {"", -9} || {currentBalance, -10}";
        }
        else
        {
            return $"{transaction.TransactionDate.ToShortDateString(), -11}|| {"", -9} || {transaction.Amount, -9} || {currentBalance, -10}";
        }
    }
}
