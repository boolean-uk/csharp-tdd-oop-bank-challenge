
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class Manager : BankUser
    {
        private BankUser _bankuser;
        private SavingsAccount _savingsaccount;
        private string branch;
        public List<Transaction> Transactions { get; } = new List<Transaction>();
        public Manager()
        {
            _bankuser = new BankUser();
            _savingsaccount = new SavingsAccount();
            this.branch = string.Empty;
    }



      


    }
}
