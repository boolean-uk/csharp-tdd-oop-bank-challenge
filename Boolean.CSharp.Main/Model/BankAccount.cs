using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class BankAccount
    {
        private TransactionsAccount _transactionsAccount { get; }
        private SavingsAccount _savingsAccount { get; }
        private List<BankStatement> _bankStatements { get; }
        private int _bankId;

        public BankAccount(int customerID)
        {
            _bankId = customerID;
            this._transactionsAccount = new TransactionsAccount();
            this._savingsAccount = new SavingsAccount(5);
            this._bankStatements = new List<BankStatement>();
        }

        public int getBankId() { return _bankId; }

        public float getTransactionsAccountBalance() { return _transactionsAccount.getBalance(); }
        public float getSavingsAccountBalance() { return _transactionsAccount.getBalance(); }
        public TransactionsAccount getTransactionsAccount() { return _transactionsAccount; }
        public SavingsAccount getSavingsAccount() { return _savingsAccount; }

        public void depositMoneyToTransactionalAccount(float amount) { this._transactionsAccount.deposit(amount, this); }

        public void depositMoneyToSavingsAccount(float amount) { this._savingsAccount.deposit(amount, this); }

        public void withdrawMoneyFromTransactionalAccount(float amount) { this._transactionsAccount.withdraw(amount, this); }
        public void withdrawMoneyFromSavingsAccount(float amount) { this._savingsAccount.withdraw(amount, this); }

        public List<BankStatement> getBankStatemets() { return _bankStatements; }

        internal void logTransaction(float transactionalValue, float balance, bool transactionalAccount, bool withdraw  ) {
            this._bankStatements.Add(new BankStatement(getDate(), transactionalValue, balance, _bankId, transactionalAccount, withdraw));
        }

        private DateTime getDate() { return DateTime.Now; }


    }
}
