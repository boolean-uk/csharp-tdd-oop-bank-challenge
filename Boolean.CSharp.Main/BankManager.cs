using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class BankManager
    {
        public BankManager()
        {

        }

        public bool RequestOverdraft(Account account, string sortCode, float amount, string date)
        {
            if (account == null)
                return false;

            if (amount == 0 || amount < 0)
                return false;

            if (date == "")
                return false;

            if (amount - account.GetTotalBalance(sortCode) > 100000)
                return false;
            
            bool request = account.WithdrawFunds(sortCode, amount, date, true);
            return request;
        }
    }
}
