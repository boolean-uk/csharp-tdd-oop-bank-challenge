﻿using Boolean.CSharp.Main.Bank;
using Boolean.CSharp.Main.ExtensionTasks.Interfaces;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Extension
{
    public class AccountEX
    {        
        public List<ITransaction> _transactions { get; set; }
        public IBranch branch { get; set; }

        public AccountEX(List<ITransaction> transactions, IBranch branch)
        {            
            this._transactions = transactions;
            this.branch = branch;
        }

        public double GetBalance() 
        {
            return _transactions.Sum(t => t._type == TransactionType.Credit ? -(t._amount) : t._amount);
        }

        public bool Deposit(double amount)
        {            
            try
            {               
                // store transaction data
                ITransaction transaction = new Transaction()
                {
                    _dateTime = DateTime.Now,
                    _amount = amount,
                    _balance = this.GetBalance(),
                    _type = TransactionType.Debit
                };
                this._transactions.Add(transaction);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }


        public bool Withdraw(double amount)
        {            
            try
            {                
                // store transaction data
                ITransaction transaction = new Transaction()
                {
                    _dateTime = DateTime.Now,
                    _amount = amount,
                    _balance = this.GetBalance(),
                    _type = TransactionType.Credit
                };
                this._transactions.Add(transaction);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public void TransactionStatement()
        {
            // var transactions is unecesarry; could have used the class property _transaction.
            // Only used to practice linq query expression. 
            var transactions = from t in this._transactions
                               orderby t._dateTime descending
                               select new
                               {
                                   date = t._dateTime.ToString("dd/mm/yyyy"),
                                   credit = t._type == TransactionType.Credit ? t._amount.ToString() : "",
                                   debit = t._type == TransactionType.Debit ? t._amount.ToString() : "",
                                   balance = t._balance
                               };
            Console.WriteLine($"{"date",-15} || {"credit",-7} || {"debit",-7} || balance");

            foreach (var t in transactions)
            {
                Console.WriteLine($"{t.date,-15} || {t.credit,-7} || {t.debit,-7} || {t.balance}");
            }
        }
    }
}
