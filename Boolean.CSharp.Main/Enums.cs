using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Enums
    {
        public Enums() { }


        public enum AccountType
        {
            Savings,
            Current
        }

        public enum TransactionType
        {
            Withdrawal,
            Deposit
        }

        public enum AccountBranch
        {
            Oslo,
            Bergen,
            Zurich,
            London,
            Monaco,
            Tokyo,
            LosAngeles,

        }

        public enum OverdraftStatus
        {
            Pending,
            Rejected,
            Approved,
            Idle
        }
    }
}
