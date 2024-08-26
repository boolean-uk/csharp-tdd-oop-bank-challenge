using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private List<Transactions> _transactions { get; set; }

        private int _accountNumber { get; set; }
        
        private string _accountBranch { get; set; }

        public string accountBranch { get { return _accountBranch; } }
        public int accountNumber { get { return _accountNumber; } }
        public List<Transactions> transactions { get { return _transactions; } }
        public string getBranch()
        {
            return null;
        }

        public float getBalance()
        {
            return 0; 
        }

        public bool transaction(Transactions transaction)
        {
            return false;
        }

        public List<Transactions> getTransactionHistory() 
        { 
            return transactions; 
        }
        public void sendTransaction()
        {
        }
    }
}
