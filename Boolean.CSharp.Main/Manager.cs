using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Manager
    {
        public Manager() { }

        public void HandleOverdraftRequest(OverdraftRequest request, bool approve)
        {
            if (approve)
            {
                request.Approve();
                request.Account.OverdraftLimit = request.RequestedAmount;
            }
            else
            {
                request.Reject();
            }
        }
    }
}
