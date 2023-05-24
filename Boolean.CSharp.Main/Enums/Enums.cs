using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Enums
{
    public enum TransactionType
    {
        Credit,
        Debit
    }

    public enum AccountType
    {
        Current,
        Savings
    }

    public enum Branches
    {
        Athens,
        London,
        Amsterdam,
        Berlin,
        Paris,
        Madrid
    }
    public enum Status
    {
        Pending,
        Approved,
        Declined
    }

}
