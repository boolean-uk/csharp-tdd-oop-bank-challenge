using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transactions
{
    public interface IOverdraftRequest
    {


        Customer GetRequester();

        decimal GetRequestOverdraftLimit();

        DateTime GetRequestDate();

        IAccount GetOverdraftRequestAccount();
    }
}
