using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class BankManager
    {

        public bool ApproveOverdraft(IAccount account, decimal amountApproved)
        {
            if (!account.OverdraftRequestIsActive)
                return false;

            account.OverdraftRequestIsActive = false;
            account.BalanceLimit = -amountApproved;
            return true;
        }

        public bool RejectOverdraft(IAccount account)
        {
            if (!account.OverdraftRequestIsActive)
                return false;

            account.OverdraftRequestIsActive = false;
            account.BalanceLimit = 0;
            return true;
        }
    }
}
