using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.AccountTypes;
using Boolean.CSharp.Main.Enums;


namespace Boolean.CSharp.Main
{
    public class OverdraftRequest
    {
        public CurrentAccount Account { get; private set; }
        public decimal RequestedAmount { get; private set; }
        public RequestStatus RequestStatus { get; set; }

        public OverdraftRequest(CurrentAccount account, decimal requestedAmount) 
        {
            Account = account;
            RequestedAmount = requestedAmount;
            RequestStatus = RequestStatus.Pending;
        }
    }
}