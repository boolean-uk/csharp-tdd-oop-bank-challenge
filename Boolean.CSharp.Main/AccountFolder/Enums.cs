using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.AccountFolder
{
    public class Enums
    {
        public enum TransactionTypes
        {
            Credit,
            Debit
        }

        public enum Branches
        {
            Rivendell,
            Numenor,
            Rohan,
            Mirkwoods
        }

        public enum OverdraftRequests
        {
            Pending,
            Denied,
            Approved
        }
    }
}
