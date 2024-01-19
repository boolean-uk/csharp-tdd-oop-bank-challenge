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
            

            throw new NotImplementedException();
        }

        public string DepositMoney(double amount)
        {
            throw new NotImplementedException();
            
        }

        public string WithdrawalMoney(double amount)
        {
            throw new NotImplementedException();
            
        }

        public void GetTransactionHistory()
        {
            throw new NotImplementedException();
        }

        private bool IsTransactionPossible()
        {
            throw new NotImplementedException();
        }

        internal class Transaction
        {
            private string _transactionDate;
            private string _creditIn;
            private string _debitOut;
            private string _ballance;


            public Transaction(double MoneyIn, double MoneyOut, double ballance) 
            {
                _transactionDate = DateTime.Today.ToString();
                _creditIn = MoneyIn.ToString();
                _debitOut = MoneyOut.ToString();
                _ballance = ballance.ToString();
                
            }

            public string transactionDate { get {return _transactionDate;} }
            public string creditIn { get { return _creditIn;} }
            public string debitOut { get { return _debitOut;} }
            public string ballance { get { return _ballance;} }
        }


    }
}
