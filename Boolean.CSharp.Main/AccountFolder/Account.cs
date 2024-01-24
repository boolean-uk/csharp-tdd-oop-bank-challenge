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
            if (transaction.Type == TransactionTypes.Credit)
            {
                if(_transactions.Count > 0)
                {
                    transaction.Balance = _transactions.Last().Balance + transaction.Amount;
                    _transactions.Add(transaction);
                }
                else
                {
                    transaction.Balance = transaction.Amount;
                    _transactions.Add(transaction);
                }
            }
        }

        public void Withdraw(Transactions transaction)
        { 
            throw new NotImplementedException();
        }

        public void printStatement()
        {
            throw new NotImplementedException();
        }

        public decimal GetBalance()
        {
            if(_transactions.Count == 0 )
            {
                return 0;
            }
            return _transactions.Last().Balance;
        }
    }
}
