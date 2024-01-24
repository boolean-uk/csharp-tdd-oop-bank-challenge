using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Enums
{
    public enum Branches
    {
        Oslo,
        Bergen,
        Stavanger,
        Kristiansand

    }

    public enum TransactionStatus
    {
        Approved,
        Pending,
        Denied
    }

    public enum TransactionType
    {
        Credit,
        Debit
    }

    public enum OverdraftStatus
    {
        Approved,
        Pending,
        Denied
    }
}
