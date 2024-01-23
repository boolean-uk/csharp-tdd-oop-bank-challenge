using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.AccountManagement
{
    public class BankAccountManager
    {
        private Dictionary<Customer, List<BankAccount>> customerAccounts;

        public BankAccountManager()
        {
            this.customerAccounts = new Dictionary<Customer, List<BankAccount>>();
        }

        public void LinkAccountToCustomer(Customer customer, BankAccount account)
        {
            throw new NotImplementedException();
        }

        public List<BankAccount> GetCustomerAccounts(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
