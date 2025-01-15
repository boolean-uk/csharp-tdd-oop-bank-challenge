using System;
using System.Text;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main;

public class BankTransaction
{
    public readonly Guid transactionId;
    public DateTime transactionDate;
    public TransactionTypes transactionType;
    public decimal transactionAmount;
    public readonly decimal currentBalance;

    public BankTransaction(DateTime transactionDate, TransactionTypes transactionType, decimal transactionAmount, decimal currentBalance)
    {
        this.transactionId = Guid.NewGuid();
        this.transactionDate = transactionDate;
        this.transactionType = transactionType;
        this.transactionAmount = transactionAmount;
        this.currentBalance = currentBalance;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(transactionDate.ToString("dd/mm/yyyy")+ " || ");
        if (transactionType == TransactionTypes.Deposit)
        {
            sb.Append(transactionAmount.ToString("F2") + " || " + "      " + " || " );
        }
        else
        {
            sb.Append("       " + " || " + Math.Abs(transactionAmount).ToString("F2") + " || ");
        }

        sb.Append(this.currentBalance.ToString());

        return sb.ToString();
    }
}
