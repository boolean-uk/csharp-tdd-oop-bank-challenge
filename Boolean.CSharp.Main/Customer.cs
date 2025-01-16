using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        private string customerId;
        private CurrentAccount currentAccount;
        private SavingAccount savingAccount;

        public Customer(string customerId, Branch branch) 
        {
            this.customerId = customerId;
            currentAccount = new CurrentAccount(branch);
            savingAccount = new SavingAccount(branch);

            currentAccount.setCustomer(this);
        }
        public string GetCustomerId { get { return customerId; } }

        public CurrentAccount GetCurrentAccount { get { return currentAccount; } }

        public SavingAccount GetSavingAccount { get {return savingAccount; } }
    }
}
