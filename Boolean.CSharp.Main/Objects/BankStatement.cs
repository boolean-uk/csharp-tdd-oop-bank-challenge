using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Interfaces;

namespace Boolean.CSharp.Main.Objects
{
    public class BankStatement
    {
        private int _id;
        private List<ITransaction> _transactions = new List<ITransaction>();
        private int _overdraftCount = 0;

        public BankStatement()
        {
            _id += 1;
        }
        public int Id { get { return _id; } set { _id = value; } }
        public List<ITransaction> Transactions { get { return _transactions; } set { _transactions = value; } }
        public int OverdraftCount { get { return _overdraftCount; } set { _overdraftCount += value; } }

        public double CalculateBalance()
        {
            double balance = 0;
            foreach(var transaction in Transactions)
            {
                if(transaction.Type == Enums.TransactionType.Deposit)
                {
                    balance += transaction.Amount;
                } else if (transaction.Type == Enums.TransactionType.Withdraw)
                {
                    balance -= transaction.Amount;
                } else
                {
                    balance += 0;
                }
            }

            return balance;
        }

    }
}