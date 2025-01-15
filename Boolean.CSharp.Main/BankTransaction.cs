using System;

namespace Boolean.CSharp.Main;

public class BankTransaction
{
    public readonly Guid transactionId;
    public DateTime transactionDate;
    public string transactionType;
    public decimal transactionAmount;

    public BankTransaction(DateTime transactionDate, string transactionType, decimal transactionAmount)
    {
        this.transactionId = Guid.NewGuid();
        this.transactionDate = transactionDate;
        this.transactionType = transactionType;
        this.transactionAmount = transactionAmount;
    }

    
}
