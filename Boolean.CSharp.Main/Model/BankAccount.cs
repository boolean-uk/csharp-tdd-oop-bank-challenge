using System;
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
        private int _bankId; //same id as owner aka customer
        public BankAccount(int customerID) {
            _bankId = customerID;
            this._transactionsAccount = new TransactionsAccount();
            this._savingsAccount = new SavingsAccount(5);
        }

        public int getBankId() { return _bankId; }
        //public TransactionsAccount getTransactionsAccount() { return _transactionsAccount; }
        //public SavingsAccount getSavingsAccount() { return _savingsAccount; }

        public bool depositMoneyToTransactionalAccount(float amount) { throw new NotImplementedException(); }

        public bool depositMoneyToSavingsAccount(float amount) { throw new NotImplementedException(); }

        public bool withdrawMoneyFromTransactionalAccount(float amount) { throw new NotImplementedException(); }
        public bool withdrawMoneyFromSavingsAccount(float amount) { throw new NotImplementedException(); }


    }
}
