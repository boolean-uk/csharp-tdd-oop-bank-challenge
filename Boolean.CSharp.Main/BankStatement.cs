using System;

namespace Boolean.CSharp.Main;

public class BankStatement
{
    public readonly Guid statementId;
    public readonly Guid accountId;
    public readonly DateTime statementDate;

    public BankStatement(Guid accountId, DateTime statementDate)
    {
        this.statementId = Guid.NewGuid();
        this.accountId = accountId;
        this.statementDate = statementDate;
    }
}
