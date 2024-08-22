﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class BankAccount
    {
        private TransactionsAccount _transactionsAccount {  get; }
        private SavingsAccount _savingsAccount { get; }
        private int _bankId; 
        public BankAccount(int customerID) {
            _bankId = customerID;
            this._transactionsAccount = new TransactionsAccount();
            this._savingsAccount = new SavingsAccount(5);
        }

        public int getBankId() { return _bankId; }

        public float getTransactionsAccountBalance() { return _transactionsAccount.getBalance(); }
        public float getSavingsAccountBalance() { return _transactionsAccount.getBalance(); }
        public TransactionsAccount getTransactionsAccount() { return _transactionsAccount; }
        public SavingsAccount getSavingsAccount() { return _savingsAccount; }

        public void depositMoneyToTransactionalAccount(float amount) { this._transactionsAccount.deposit(amount); }

        public void depositMoneyToSavingsAccount(float amount) { this._savingsAccount.deposit(amount); }

        public void withdrawMoneyFromTransactionalAccount(float amount) { this._transactionsAccount.withdraw(amount); }
        public void withdrawMoneyFromSavingsAccount(float amount) { this._savingsAccount.withdraw(amount); }


    }
}
