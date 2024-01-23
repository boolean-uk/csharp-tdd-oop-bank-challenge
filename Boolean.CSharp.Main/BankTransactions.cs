using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class BankTransactions
    {
        public DateTime _date;
        public double _amount;
        public double _balance;
        public Enums.TransactionType transactionType;

        public BankTransactions(Double amount, Enums.TransactionType transaction, double balance)
        {
            _date = DateTime.Now;
            _amount = amount;
            _balance = balance;
            if (transaction == Enums.TransactionType.Deposit)
            {
                transactionType = Enums.TransactionType.Deposit;
            }
            else if (transaction == Enums.TransactionType.Withdrawal)
            {
                transactionType = Enums.TransactionType.Withdrawal;
            }
        }


    }
}
