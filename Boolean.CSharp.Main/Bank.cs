using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        public List<Customer> customerList = new List<Customer>();
        public List<Account> accountList = new List<Account>();
        
        
        public void addCustomer(Customer customer)
        {
            customerList.Add(customer);
        }

        public void removeCustomer(Customer customer)
        {
            customerList.Remove(customer);
        }

        public void addAccount(Account account)
        {
            accountList.Add(account);
        }
        public void removeAccount(Account account)
        {
            accountList.Remove(account);
        }


    }
}
