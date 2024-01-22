using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Boolean.CSharp.Main
{
    public class Account
    {
        private double _balance; //default 0
        private string _accountID;
        private List<Transaction> _transactionHistory;

        public Account(string accountID) 
        {
            _balance = 0;
            _accountID = accountID;
            _transactionHistory = new List<Transaction>();
        }
        public double Balance { get { return _balance; } }
        public string AccountID { get { return _accountID; } }


        public string GetAcountBalance()
        {


            return _balance.ToString();
        }

        public string DepositMoney(double amount)
        {
            if (amount < 0)
            {
                TransactionIsNotPossible("amount can not be a negative number");
            }
            _balance += amount;
            Transaction transaction = new Transaction(amount, 0d, Balance);
            _transactionHistory.Add(transaction);

            return new string($"{amount} was added to the Account({AccountID})");
            
        }

        public string WithdrawMoney(double amount)
        {

            if (_balance < amount)
            {
                TransactionIsNotPossible("Can not withdraw more than what is on the acount ");
            }
            if (amount < 0 )
            {
                TransactionIsNotPossible("amount can not be a negative number");
            }
            _balance -= amount;
            Transaction transaction = new Transaction(0d, amount, Balance);
            _transactionHistory.Add(transaction);

            return new string($"{amount} was removed from the Account({AccountID})");

        }

        public List<string> GetTransactionHistory()
        {
            List<string> temp = new List<string>();
            temp.Add("Date       || credit || debit || balance");
            
            foreach (Transaction transaction in _transactionHistory)
            {
                string history = new string($"{transaction.transactionDate} || +{transaction.creditIn} || -{transaction.debitOut} || {transaction.ballance}");
                temp.Add(history);
            }
            foreach(string print in temp)
            {
                Console.WriteLine(print);
            }
            
            return temp;
        }

        private bool TransactionIsNotPossible(string message)
        {
            throw new TransactionNotPossible(message);
        }

        internal class Transaction
        {
            private string _transactionDate;
            private string _creditIn;
            private string _debitOut;
            private string _ballance;


            public Transaction(double MoneyIn, double MoneyOut, double ballance) 
            {
                _transactionDate = DateTime.Now.ToString("yyyy-MM-dd");
                _creditIn = MoneyIn.ToString("0.##");
                _debitOut = MoneyOut.ToString("0.##");
                _ballance = ballance.ToString("0.##");
                
            }

            public string transactionDate { get {return _transactionDate;} }
            public string creditIn { get { return _creditIn;} }
            public string debitOut { get { return _debitOut;} }
            public string ballance { get { return _ballance;} }
        }


    }

    public class TransactionNotPossible : Exception
    {
        public TransactionNotPossible(string message) : base(message) { }
    }
}
