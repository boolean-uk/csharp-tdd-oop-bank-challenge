using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }

    public enum AccountType
    {
        CurrentAccount,
        SavingsAccount
    }

    public enum BankLocation
    {
        Stavanger,
        Oslo,
        Bergen,
        Kristiansand
    }

    public enum OverdraftStatus
    {
        Approved,
        Rejected,
        Pending
    }
}
