using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branches;
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
        private Dictionary<Branch, List<BankAccount>> branchAccounts;

        public BankAccountManager()
        {
            this.customerAccounts = new Dictionary<Customer, List<BankAccount>>();
            this.branchAccounts = new Dictionary<Branch, List<BankAccount>>();
        }

        public void LinkAccountToCustomer(Customer customer, BankAccount account)
        {
            if (customerAccounts.TryGetValue(customer, out List<BankAccount>? accounts)) accounts.Add(account);
            else customerAccounts[customer] = new List<BankAccount> { account };
        }

        public void LinkAccountToBranch(Branch branch, BankAccount account)
        {
            if (branchAccounts.TryGetValue(branch, out List<BankAccount>? accounts)) accounts.Add(account);
            else branchAccounts[branch] = new List<BankAccount> { account };
        }

        public List<BankAccount> GetCustomerAccounts(Customer customer)
        {
            if (customerAccounts.TryGetValue(customer, out List<BankAccount>? accounts)) return accounts;
            else return new List<BankAccount>();
        }

        public List<BankAccount> GetBranchAccounts(Branch branch)
        {
            if (branchAccounts.TryGetValue(branch, out List<BankAccount>? accounts)) return accounts;
            else return new List<BankAccount>();
        }
    }
}
