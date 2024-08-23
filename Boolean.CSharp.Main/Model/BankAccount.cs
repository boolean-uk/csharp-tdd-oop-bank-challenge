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

        public float getTransactionsAccountBalance()
        {
            float balance = 0.0f;
            _bankStatements.ForEach(statement =>
            {
                if (statement.transactionalAccount() && !statement.withdraw())
                {
                    balance += statement.transactionValue();
                }
                else if (statement.transactionalAccount() && statement.withdraw()) 
                {
                    balance -= statement.transactionValue();
                }
            });
            return balance;
        }

        public float getSavingsAccountBalance()
        {
            float balance = 0.0f;
            _bankStatements.ForEach(statement =>
            {
                if (!statement.transactionalAccount() && !statement.withdraw())
                {
                    balance += statement.transactionValue();
                }
                else if (!statement.transactionalAccount() && statement.withdraw())
                {
                    balance -= statement.transactionValue();
                }
            });
            return balance;
        }
        public TransactionsAccount getTransactionsAccount() { return _transactionsAccount; }
        public SavingsAccount getSavingsAccount() { return _savingsAccount; }

        public void depositMoneyToTransactionalAccount(float amount) { this._transactionsAccount.deposit(amount, this); }

        public void depositMoneyToSavingsAccount(float amount) { this._savingsAccount.deposit(amount, this); }

        public void withdrawMoneyFromTransactionalAccount(float amount) { this._transactionsAccount.withdraw(amount, this); }
        public void withdrawMoneyFromSavingsAccount(float amount) { this._savingsAccount.withdraw(amount, this); }

        public List<BankStatement> getBankStatemets() { return _bankStatements; }

        internal void logTransaction(float transactionalValue, bool transactionalAccount, bool withdraw)
        {
            if (transactionalAccount && !withdraw)
            {
                this._bankStatements.Add(new BankStatement(getDate(), transactionalValue, transactionalValue + getTransactionsAccountBalance(), _bankId, transactionalAccount, withdraw));
            }
            else if (transactionalAccount && withdraw)
            {
                this._bankStatements.Add(new BankStatement(getDate(), transactionalValue, getTransactionsAccountBalance() - transactionalValue, _bankId, transactionalAccount, withdraw));
            }
            else if (!transactionalAccount && !withdraw) 
            {
                this._bankStatements.Add(new BankStatement(getDate(), transactionalValue, transactionalValue + getSavingsAccountBalance(), _bankId, transactionalAccount, withdraw));
            }
            else
            {
                this._bankStatements.Add(new BankStatement(getDate(), transactionalValue, getSavingsAccountBalance() - transactionalValue, _bankId, transactionalAccount, withdraw));
            }
        }
        private DateTime getDate() { return DateTime.Now; }


    }
}
