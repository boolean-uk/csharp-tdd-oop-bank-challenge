using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Enums
{
    public enum Transaction
    {
        Deposit,
        Withdraw
    }

    public enum Account
    {
        Current,
        Savings
    }

    public enum Overdraft
    {
        Appending,
        Approved,
        Rejected

    }

    public enum Branch
    {
        Sandnes,
        Stavanger,
        Oslo

    }
}
