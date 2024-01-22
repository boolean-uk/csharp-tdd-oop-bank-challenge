using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.enums
{
    public enum AccountType
    {
        Current,
        Savings
    }

    public enum TransactionType
    {
        Debit,
        Credit
    }

    public enum TransactionStatus
    {
        Pending,
        Approved,
        Refused
    }
}
