using System;

namespace Boolean.CSharp.Main;

public class BankBranch
{
    public readonly Guid branchId;
    public string branchName;

    public BankBranch(string branchName)
    {
        this.branchId = Guid.NewGuid();
        this.branchName = branchName;
    }

}
