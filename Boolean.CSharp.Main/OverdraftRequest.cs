using System;
using Boolean.CSharp.Main.Exceptions;
using Boolean.CSharp.Main.Enums;


namespace Boolean.CSharp.Main;

public class OverdraftRequest
{
    public readonly Guid accountId;
    public readonly BankTransaction transaction;

    public bool _approved { get; private set; }
    
    public event Action<OverdraftRequest> OverdraftApproved;

    public OverdraftRequest(Guid accountId, BankTransaction transaction)
    {
        this.accountId = accountId;
        this.transaction = transaction;
        _approved = false;
    }

    public void Approve(Role role)
    {
        if (role == Role.Manager) 
        {
            _approved = true;
            OverdraftApproved?.Invoke(this);
        }
        else throw new NotManagerException();
    }

}
