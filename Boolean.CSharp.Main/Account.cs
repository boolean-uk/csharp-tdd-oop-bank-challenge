using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Boolean.CSharp.Main
{
    public enum BankBranch
    {
        London, 
        Stockholm, 
        Liverpool, 
        Gothenburg
    }
    public class Account
    {
        
        private string _accountID;
        private List<Transaction> _transactionHistory;

        private OverdraftRequest _overdraftRequest;

        public bool makeAnOverdraftRequests;

        private BankBranch _bankBranch;

        public Account(string accountID, BankBranch bankBranch) 
        {
            
            _accountID = accountID;
            _transactionHistory = new List<Transaction>();
            makeAnOverdraftRequests = false;
            _bankBranch = bankBranch;
        }
        
        public string AccountID { get { return _accountID; } }
        public BankBranch BankBranch { get { return _bankBranch; } }
        


        public double GetAcountBalance()
        {
            double temp = 0;
            foreach (Transaction t in _transactionHistory)
            {
                temp += t.creditIn;
                temp -= t.debitOut;
            }

            return temp;
        }

        public string DepositMoney(double amount)
        {
            if (amount < 0)
            {
                SendMessageToPhone("amount can not be a negative number");
                TransactionIsNotPossible("amount can not be a negative number");
            }
            
            Transaction transaction = new Transaction(amount, 0d, GetAcountBalance() + amount);
            _transactionHistory.Add(transaction);
            SendMessageToPhone($"{amount} was added to the Account({AccountID})");
            return new string($"{amount} was added to the Account({AccountID})");
            
        }

        public string WithdrawMoney(double amount)
        {

            if (GetAcountBalance() < amount)
            {
                if (makeAnOverdraftRequests)
                {
                    _overdraftRequest = new OverdraftRequest(amount - GetAcountBalance());
                    BankManager bankManager = new BankManager(_overdraftRequest);
                    _overdraftRequest = bankManager.LookAtRequests();

                    if (_overdraftRequest.status == OverdraftRequest.RequestStatus.Approved) 
                    {
                        Transaction t = new Transaction(0d, amount, GetAcountBalance() - amount);
                        _transactionHistory.Add(t);
                        SendMessageToPhone($"{amount} was removed from the Account({AccountID})");
                        return new string($"{amount} was removed from the Account({AccountID})");
                    }
                    else
                    {
                        SendMessageToPhone("OverdraftRequest Denied");
                        TransactionIsNotPossible("OverdraftRequest Denied");

                    }
                }
                else
                {   
                    SendMessageToPhone("Not able to take more money from account than there is");
                    TransactionIsNotPossible("Not able to take more money from account than there is");
                }

            }
            if (amount < 0 )
            {   
                SendMessageToPhone("amount can not be a negative number"); 
                TransactionIsNotPossible("amount can not be a negative number");
            }
            
            Transaction transaction = new Transaction(0d, amount, GetAcountBalance() - amount);
            _transactionHistory.Add(transaction);
            SendMessageToPhone($"{amount} was removed from the Account({AccountID})");
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

        private void SendMessageToPhone(string message)
        {
            Console.WriteLine(message);
        }

        private bool TransactionIsNotPossible(string message)
        {
            throw new TransactionNotPossible(message);
        }

        internal class Transaction
        {
            private string _transactionDate;
            private double _creditIn;
            private double _debitOut;
            private double _ballance;


            public Transaction(double MoneyIn, double MoneyOut, double ballance) 
            {
                _transactionDate = DateTime.Now.ToString("yyyy-MM-dd");
                _creditIn = MoneyIn;
                _debitOut = MoneyOut;
                _ballance = ballance;
                
            }

            public string transactionDate { get {return _transactionDate;} }
            public double creditIn { get { return _creditIn;} }
            public double debitOut { get { return _debitOut;} }
            public double ballance { get { return _ballance;} }
        }


    }

    public class TransactionNotPossible : Exception
    {
        public TransactionNotPossible(string message) : base(message) { }
    }
}
