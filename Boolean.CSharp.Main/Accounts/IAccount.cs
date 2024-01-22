using Boolean.CSharp.Main.Accounts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public interface IAccount
    {
        string _AccId { get; set; }
        bool _IsAccActive { get; set; }
        Branches _Branch { get; }

        double getBlance();
        void Deposit(Transaction transaction);
        void Withdraw(Transaction transaction);
        List<Transaction> getOverview();
        bool getAccountStatus();

        

    }
}
