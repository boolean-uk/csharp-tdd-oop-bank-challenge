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
            if (customerAccounts.TryGetValue(customer, out List<BankAccount>? accounts)) accounts.Add(account);
            else customerAccounts[customer] = new List<BankAccount> { account };
        }

        public List<BankAccount> GetCustomerAccounts(Customer customer)
        {
            if (customerAccounts.TryGetValue(customer, out List<BankAccount>? accounts)) return accounts;
            else return new List<BankAccount>();
        }
    }
}
