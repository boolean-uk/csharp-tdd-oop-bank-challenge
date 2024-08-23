using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class TransactionsAccount
    {
        private float _balance { get; set; }

        internal TransactionsAccount() { 
        this._balance = 0f;
        }
        //internal float getBalance() { return this._balance; }

        internal void deposit(float amount, BankAccount bankAccount) { _balance += amount; bankAccount.logTransaction(amount, true, false); }
        internal float withdraw(float amount, BankAccount bankAccount) { _balance -= amount; bankAccount.logTransaction(amount, true, true);  return amount; }
    }
}
