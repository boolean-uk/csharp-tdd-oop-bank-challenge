using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Manager
    {
        public bool ApproveOverdraft(Account account, decimal approvedAmount)
        {
            if (account.OverdraftActive)
            {
                account.OverdraftActive = false;
                account.BalanceCapacity = -approvedAmount;
                return true;
            }
            return false;
        }

        public bool RejectOverdraft(Account account)
        {
            if (account.OverdraftActive)
            {
                account.OverdraftActive = false;
                account.BalanceCapacity = 0;
                return true;
            }

            return false;
        }
    }
}
