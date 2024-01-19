using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main.Enums
{
    public enum TransactionType
    {
        Credit,
        Debit
    }

    public enum BranchLocation
    {
        London,
        Athens,
        Amsterdam
    }

    public enum OverdraftStatus
    {
        Pending,    // customer has requested an overdraft
        Rejected,   // bank manager has rejected the overdraft request
        Approved,   // bank manager has approved the overdraft request
    }
}
