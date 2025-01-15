using System;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main;

public class BankBranch
{
    public readonly Guid branchId;
    public string branchName;

    private List<OverdraftRequest> overdraftRequests;

    public BankBranch(string branchName)
    {
        this.branchId = Guid.NewGuid();
        this.branchName = branchName;
        this.overdraftRequests = new List<OverdraftRequest>();
    }

    public void AddOverdraftRequest(OverdraftRequest overdraftRequest)
    {
        this.overdraftRequests.Add(overdraftRequest);
    }

    public void RejectOverdraftRequest(OverdraftRequest overdraftRequest)
    {
        this.overdraftRequests.Remove(overdraftRequest);
    }

    public void ApproveOverdraftRequest(OverdraftRequest overdraftRequest, Role role)
    {
        overdraftRequest.Approve(role);
    }

    public List<OverdraftRequest> GetOverdraftRequests()
    {
        return this.overdraftRequests;
    }
}
