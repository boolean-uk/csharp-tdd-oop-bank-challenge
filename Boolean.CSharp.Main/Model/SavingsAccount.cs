﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class SavingsAccount
    {
        private float _balance { get; set; }
        private int _interestRate { get; set; }

        internal SavingsAccount(int interestRate)
        {
            this._balance = 0f;
            this._interestRate = 0;
        }
        //internal float getBalance() { return this._balance; }



        internal void deposit(float amount, BankAccount bankAccount) { _balance += amount; bankAccount.logTransaction(amount, false, false); }
        internal float withdraw(float amount, BankAccount bankAccount) { _balance -= amount; bankAccount.logTransaction(amount    , false, true);  return amount;  }
    }
}
