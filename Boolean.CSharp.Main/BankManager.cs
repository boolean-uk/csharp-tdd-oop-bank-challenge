using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class BankManager
    {
        public OverdraftRequest OverdraftRequest;

        public BankManager(OverdraftRequest overdraftRequest)
        {
            OverdraftRequest = overdraftRequest;
        }

        public OverdraftRequest LookAtRequests()
        {
            if(OverdraftRequest.amountRequested < 200 && OverdraftRequest.amountRequested > 0)
            {
                OverdraftRequest.SetStatus(OverdraftRequest.RequestStatus.Approved);
                return OverdraftRequest;
            }
            else
            {
                OverdraftRequest.SetStatus(OverdraftRequest.RequestStatus.Denied);
                return OverdraftRequest;
            }
        }
    }
}
