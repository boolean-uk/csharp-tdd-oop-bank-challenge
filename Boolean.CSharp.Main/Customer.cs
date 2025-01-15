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

        public Customer(string customerId, Branch branch) 
        {
            this.customerId = customerId;
            this.currentAccount = new CurrentAccount(branch);

            this.currentAccount.setCustomer(this);
        }
        public string GetCustomerId { get { return customerId; } }

        public CurrentAccount GetCurrentAccount { get { return currentAccount; } }
    }
}
