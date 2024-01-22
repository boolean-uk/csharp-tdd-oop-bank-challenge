using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public enum eType
    {
        Debit,  //  Withdraw
        Credit,  //  Deposit
        OverDraft  //  Deposit
    }

    public enum eBranch
    {
        Central,
        West,
        WestWest,
        East,
        North
    }

    public enum eStatus
    {
        Pending,
        Approved,
        Denied
    }
}
