using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Account
{
    public class Transaction : ITransaction
    {
        private TransactionType _transactionType;
        private DateTime _transactionTime;
        private decimal _amount;
        private decimal _newBalance;
        
        public Transaction(DateTime time, TransactionType type, decimal amount, decimal newbalanace) { 
            _transactionTime = time;
            _transactionType = type;
            _amount = amount;
            _newBalance = newbalanace;
        
        
        }

       /// <summary>
       /// checking the transaction receipt if the user has an account then returns true anc console logs the receipt
       /// else it returns false
       /// </summary>
       /// <param name="user"></param>
       /// <param name="account"></param>
       /// <returns></returns>
        public bool TransactionsReceipt(User user, Account account) {
            Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10} ", "Date", "Transaction Type", "Amount", "Balance");
            if(account.firstName == user.firstName)
            {

                foreach (Transaction tran in user.transactions)
                {
                    Console.WriteLine("{0,10} || {1,10}       || {2,10} || {3,10} ", $"{tran.transactionTime.ToString("d/M/yyyy")}", $"{tran.TransactionType}", $"{tran.transactionAmount}", $"{tran.newBalance}");

                }
                return true;
            }
            else {  return false; }
        }
       

        public TransactionType TransactionType { get { return _transactionType; } set { _transactionType = value; } }
        public DateTime transactionTime { get { return _transactionTime; } set { _transactionTime = value; } }
        public decimal transactionAmount { get { return _amount; } set { _amount = value; } }
        public decimal newBalance { get { return _newBalance; } set { _newBalance = value; } }

    }
}
