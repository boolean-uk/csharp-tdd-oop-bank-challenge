using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account
    {
        public int customerId;
        public int accountNumber;
        public IBranch branch;
        private List<string> history = new List<string>();
        protected Account(int customerId, int accountNumber, IBranch branch)
        {
            this.customerId = customerId;   
            this.accountNumber = accountNumber;
            this.branch = branch;
        }

        public void Deposit(double funds)
        {

        }

        public double Balance()
        {
            return 0;
        }
    }
}
