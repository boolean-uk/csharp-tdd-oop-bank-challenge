using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class BankAccount
    {
        private TransactionsAccount _transactionsAccount;
        private SavingsAccount _savingsAccount;
        private int _bankId; //same id as owner aka customer
        public BankAccount(int customerID) {
            _bankId = customerID;
        }

        public int getBankId() { return _bankId; }
        public TransactionsAccount getTransactionsAccount() { return _transactionsAccount; }
        public SavingsAccount getSavingsAccount() { return _savingsAccount; }


    }
}
