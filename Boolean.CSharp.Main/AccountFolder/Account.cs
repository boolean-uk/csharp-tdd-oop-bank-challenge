using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.AccountFolder
{
    public abstract class Account
    {

        private List<Transactions> _transactions = new List<Transactions>();

        public void Deposit(Transactions transaction)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(Transactions transaction)
        { 
            throw new NotImplementedException();
        }

        public void printStatement()
        {
            throw new NotImplementedException();
        }

        public int GetBalance()
        {
            throw new NotImplementedException();
        }
    }
}
