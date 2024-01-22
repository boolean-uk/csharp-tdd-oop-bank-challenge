using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public interface IUser
    {
        string GetName();

        List<IAccount> GetAccounts();

        bool RegisterWithBankBranch(IBankBranch branch);
    }
}
