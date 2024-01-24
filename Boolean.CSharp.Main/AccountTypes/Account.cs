using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main;


namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private int _id;
        private string _type;
        private decimal _availableAmount;
        private List<Transaction> _bankTransactions = new List<Transaction>();
        private HeadQuarters _bank = new HeadQuarters();
        private int _uniqueId = 0;
        private List<Transaction> _overdraftRequestsList = new List<Transaction>();

        public Account()
        {
            _id = _bank.GenerateAccountId();
            _type = "current";
            _availableAmount = 0;
        }
        public void Deposit(decimal amount)
        {
            BankTransaction BankTransaction = new BankTransaction(id:_uniqueId, amount, oldAmount:_availableAmount);
            _availableAmount += amount;
            _bankTransactions.Add(BankTransaction.GetTransaction());
            _uniqueId++;

        }
        public string Withdraw(decimal amount)
        {
            string message = string.Empty;
            if(_availableAmount > amount)
            {
                BankTransaction BankTransaction = new BankTransaction(id: _uniqueId, -amount, oldAmount: _availableAmount);
                _availableAmount -= amount;
                message = $"withdrawn amount: {amount}";
                _bankTransactions.Add(BankTransaction.GetTransaction());
                _uniqueId++;
                
            }
            else { message = RequestOverdraft(amount).Value; }
            
            return message;
        }

        public KeyValuePair<int,string> RequestOverdraft(decimal amount)
        {
            if(_availableAmount > amount)
            {
                return new KeyValuePair<int, string>(0,"Request approved - no overdraft needed");
            }
            else
            {
                BankTransaction transaction = new BankTransaction(id: _uniqueId, -amount, oldAmount: _availableAmount);
                _overdraftRequestsList.Add(transaction.GetTransaction());
                _uniqueId++;
                return new KeyValuePair<int, string>(transaction.Id, "Request is pending");
            }
            
        }
        public string CheckTransactionStatus(int id)
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach(Transaction t in _bankTransactions) { if(t.TransactionId == id) { 
                return ($"TransactionId: {id}, Transaction status: {t.TransactionStatus}. New Balance: {t.Balance}");
                }
            }
           
                
             if(transactions.Count == 0)
            {
                foreach (Transaction t in _overdraftRequestsList) { if (t.TransactionId == id) { return ($"TransactionId:{id}, Overdraftrequest Status: {t.TransactionStatus}"); } }
                if (transactions.Count != 0)
                {
                    
                }
            }
             return "Id not found"; 

        }
        


        protected void SetType(string type) { _type = type; }

        public decimal CalculateBalance() {
            decimal newBalance = 0;

            if (_bankTransactions.Count > 0)
            {
                foreach(Transaction transaction in _bankTransactions)
                {
                    if (transaction.TransactionType == "credit")
                    {
                        newBalance += transaction.TransactionAmount;
                    }else if(transaction.TransactionType == "debit")
                    {
                        newBalance -= transaction.TransactionAmount;
                    }
                }
            }

            return newBalance;
        }
        public string GenerateBankStatement()
        {
            StringBuilder sb = new StringBuilder();
            _bankTransactions.Sort((a, b) => DateTime.Compare(a.Date, b.Date));

            string TransactionId = "Id";
                string Date = "Date";
                string Credit = "Credit";
                string Debit = "Debit";
                string Balance = "Balance";
            sb.Append("New Bankstatement\n");
            Console.WriteLine($"\n{TransactionId,-5}\t|| {Date,-10} || {Credit,-6}\t|| {Debit,-6} || {Balance}");
            sb.Append($"\n{TransactionId,-5}\t|| {Date,-10} || {Credit,-6}\t|| {Debit,-6} || {Balance}");
                foreach(Transaction transaction in _bankTransactions)
                {
                    TransactionId = transaction.TransactionId.ToString();
                    Date = transaction.Date.ToString().Substring(0,10);
                    if (transaction.TransactionType == "credit")
                    {
                        Credit = transaction.TransactionAmount.ToString();
                        Debit = " ";
                    }else if (transaction.TransactionType == "debit")
                    {
                        Debit = transaction.TransactionAmount.ToString();
                        Credit = " ";
                    }
                    Balance = transaction.Balance.ToString();
                Console.WriteLine("{0,-5}\t|| {1,-10} || {2,-6}\t|| {3,-6} || {4}", TransactionId, Date, Credit, Debit, Balance);
                sb.Append($"\n{TransactionId,-5}\t|| {Date,-10} || {Credit,-6}\t|| {Debit,-6} || {Balance}");
            }
            
            
            return sb.ToString();
        }

        public void SortTransactionList(List<Transaction> list)
        {
            foreach(Transaction transaction in list)
            {
                if(transaction.TransactionStatus == Status.approved.ToString())
                {
                    
                        _availableAmount -= transaction.TransactionAmount;
                                     
                    _bankTransactions.Add(transaction);
                    _overdraftRequestsList.Remove(transaction);
                }
                
            }
        }

        public string Type { get => _type; set => _type = value; }
        public decimal Balance { get => _availableAmount; set => _availableAmount=value; }
        public int Id { get =>  _id; set => _id = value;}
        public List<Transaction> BankTransactions { get => _bankTransactions; }
        public List<Transaction> OverdraftRequests { get => _overdraftRequestsList; }
        

       
    }
}
