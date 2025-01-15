using System;

namespace Boolean.CSharp.Main;

public class BankBranch
{
    public readonly Guid brachId;
    public string branchName;
    public string branchAddress;

    public BankBranch(string branchName, string branchAddress)
    {
        this.brachId = Guid.NewGuid();
        this.branchName = branchName;
        this.branchAddress = branchAddress;
    }

}
