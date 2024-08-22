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
        private int _bankId;
        public BankAccount(Customer customer) {
            //this._bankId = customer.getCustomerID();
        }
    }
}
