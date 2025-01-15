using System;

namespace Boolean.CSharp.Main;

abstract class Account
{
    public readonly Guid accountId;
    public readonly string accountName;
    public readonly Guid userId;
    public readonly Guid bankBranchId;


    public Account(string accountName, Guid userId, Guid bankBranchId)
    {
        this.accountId = Guid.NewGuid();
        this.accountName = accountName;
        this.userId = userId;
        this.bankBranchId = bankBranchId;
    }

}
