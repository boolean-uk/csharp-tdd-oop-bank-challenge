using System;
using System.Text;

namespace Boolean.CSharp.Main;

public class BankStatement
{
    public readonly Guid statementId;
    public readonly Guid accountId;
    public readonly List<BankTransaction> transactions;

    public BankStatement(Guid accountId, List<BankTransaction> transactions)
    {
        this.statementId = Guid.NewGuid();
        this.accountId = accountId;
        this.transactions = transactions;
    }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(" date      || credit  || debit  || balance");

        transactions.Reverse();
        transactions.ForEach(t => sb.Append(t.ToString() + "\n"));
        return sb.ToString();
    }

}
