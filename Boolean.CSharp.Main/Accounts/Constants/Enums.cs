using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts.Constants
{
    public enum Enums
    {
        Current,
        Saving
    }

    public enum Branches
    {
        Bergen,
        Oslo,
        Trondheim,
        Stavanger,
        Kristiansand
    }

    public enum TransactionType
    {
        Deposit,
        Withdraw,
        Loan,
        Overdraft
    }
}
