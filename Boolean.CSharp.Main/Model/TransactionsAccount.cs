using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class TransactionsAccount
    {
        private float _balance {  get; set; }

        public TransactionsAccount() { 
        this._balance = 0f;
        }
        public float getBalance() { return this._balance; }

        public void deposit(float amount, BankAccount bankAccount) { _balance += amount; bankAccount.logTransaction(amount, _balance, true, false); }
        public float withdraw(float amount, BankAccount bankAccount) { _balance -= amount; bankAccount.logTransaction(amount, _balance, true, true);  return amount; }
    }
}
