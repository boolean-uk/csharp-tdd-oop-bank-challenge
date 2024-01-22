using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private int _id;
        private string _type;
        private decimal _availableAmount;
        private List<string[]> _bankTransactions;
        private Bank _bank = new Bank();
        private int _uniqueId = 0;

        public Account()
        {
            _bankTransactions = new List<string[]>();
            _id = _bank.GenerateAccountId();
            _type = "current";
            _availableAmount = 0;
        }
        public void Deposit(decimal amount)
        {
            BankTransaction transaction = new BankTransaction(id:_uniqueId, amount, oldAmount:_availableAmount);
            _availableAmount += amount;
            Console.WriteLine("deposited amount: {0}",amount);

            _bankTransactions.Add(transaction.GetTransactionString());
            _uniqueId++;

        }
        public bool Withdraw(decimal amount)
        {
            if(_availableAmount > amount)
            {
                BankTransaction transaction = new BankTransaction(id: _uniqueId, -amount, oldAmount: _availableAmount);
                _availableAmount -= amount;
                Console.WriteLine("withdrawn amount: {0}", amount);
                _bankTransactions.Add(transaction.GetTransactionString());
                _uniqueId++;
                return true;
            }
            return false;
        }

        protected void SetType(string type) { _type = type; }

        public bool GenerateBankStatement()
        {
            _bankTransactions.Reverse();
                string TransactionId = "\nId";
                string Date = "Date";
                string Credit = "Credit";
                string Debit = "Debit";
                string Balance = "Balance";

                Console.WriteLine("{0,-5}\t|| {1,-10} || {2,-6}\t|| {3,-6} || {4}", TransactionId,Date,Credit,Debit,Balance);
                foreach(string[] transaction in _bankTransactions)
                {
                    TransactionId = transaction[0];
                    Date = transaction[1];
                    if (transaction[2] == "credit")
                    {
                        Credit = transaction[3];
                        Debit = " ";
                    }else if (transaction[2] == "debit")
                    {
                        Debit = transaction[3];
                        Credit = " ";
                    }
                    Balance = transaction[4];
                Console.WriteLine("{0,-5}\t|| {1,-10} || {2,-6}\t|| {3,-6} || {4}", TransactionId, Date, Credit, Debit, Balance);

            }
            return true;
        }
       
        public string Type { get => _type; }
        public decimal Balance { get => _availableAmount; set => _availableAmount=value; }
        public int Id { get =>  _id; set => _id = value;}
        public List<string[]> BankTransactions { get => _bankTransactions; }
    }
}
