using System;   
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Bank
{   
    public class Bank
    {
        public Dictionary<Customer, Dictionary<Guid, Account>> accountDirectory = new Dictionary<Customer, Dictionary<Guid, Account>>();
      

        public Bank() { }

        public bool CreateCurrentAccount(Customer customer, out Guid accountNumber)
        {
            try
            {
                accountNumber = new Guid();
                CurrentAccount currentAccount = new CurrentAccount(0);
                bool userExists = this.accountDirectory.ContainsKey(customer);                

                if (userExists)
                {
                    var accountsToCustomer = this.accountDirectory[customer];
                    accountsToCustomer.Add(accountNumber, currentAccount);                    
                }
                else
                {
                    accountDirectory.Add(customer, new Dictionary<Guid, Account>());
                    var accountsToCustomer = this.accountDirectory[customer];
                    accountsToCustomer.Add(accountNumber, currentAccount);
                }
                return true;
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex);
                accountNumber = new Guid();
                return false;
            }
        }

        public bool CreateSavingsAccount(Customer customer, out Guid accountNumber)
        {
            try
            {
                accountNumber = new Guid();
                SavingsAccount savingsAccount = new SavingsAccount(0);                
                bool userExists = this.accountDirectory.ContainsKey(customer);

                if (userExists)
                {
                    var accountsToCustomer = accountDirectory[customer];
                    accountsToCustomer.Add(accountNumber, savingsAccount);
                }
                else
                {
                    accountDirectory.Add(customer, new Dictionary<Guid, Account>());
                    var accountsToCustomer = accountDirectory[customer];
                    accountsToCustomer.Add(accountNumber, savingsAccount);
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                accountNumber = new Guid();
                return false;
            }
        }

        public bool Deposit(Guid guid, double amount, Customer customer)
        {
            if (this.accountDirectory.ContainsKey(customer))
            {
                if (this.accountDirectory[customer].ContainsKey(guid))
                {
                    Account account = this.accountDirectory[customer][guid];
                    bool depositOK = account.Deposit(amount);
                    return depositOK;
                }
                throw new KeyNotFoundException($"KEY: {guid} was not found in the dictionary");
            }
            throw new KeyNotFoundException($"Key: {customer} was not found in the dictionary");
        }

        public bool Withdraw(Guid guid, double amount, Customer customer)
        {
            if (this.accountDirectory.ContainsKey(customer))
            {
                if (this.accountDirectory[customer].ContainsKey(guid))
                {
                    Account account = this.accountDirectory[customer][guid];
                    bool withdrawOK = account.Withdraw(amount);
                    return withdrawOK;
                }
                throw new KeyNotFoundException($"KEY: {guid} was not found in the dictionary");
            }
            throw new KeyNotFoundException($"Key: {customer} was not found in the dictionary");
        }
    }
}
