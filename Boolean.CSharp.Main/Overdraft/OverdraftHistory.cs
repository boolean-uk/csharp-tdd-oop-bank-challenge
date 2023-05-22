using System;
using System.Collections.Generic;
using System.Linq;
using BankingApp.Boolean.CSharp.Main;
using BankingApp.Boolean.CSharp.Main.Accounts;
using BankingApp.Boolean.CSharp.Main.Overdraft;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Boolean.CSharp.Main.Overdraft
{
    public class OverdraftHistory
    {
        public List<OverdraftRequest> Requests { get; set; }

        public OverdraftHistory()
        {
            Requests = new List<OverdraftRequest>();

        }

        public void AddRequest(OverdraftRequest request)
        { Requests.Add(request); }

        public void ApproveRequest(OverdraftRequest request)
        {
            request.IsApproved = true;
           request.Account.OverdraftLimit = request.RequestedAmount;
        }
    }
}
