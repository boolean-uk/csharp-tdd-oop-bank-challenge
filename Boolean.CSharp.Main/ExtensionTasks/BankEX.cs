using Boolean.CSharp.Main.Bank;
using Boolean.CSharp.Main.ExtensionTasks;
using Boolean.CSharp.Main.ExtensionTasks.Branch;
using Boolean.CSharp.Main.ExtensionTasks.Interfaces;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Extension
{
    public class BankEX
    {
        public Dictionary<Customer, Dictionary<Guid, AccountEX>> accountDirectory = new Dictionary<Customer, Dictionary<Guid, AccountEX>>();
        public object OverdraftDirectory { get; set; }
        public List<IOverdraft> overdraftDirectory { get; set; } = new List<IOverdraft>();
        public BankEX() { }        

        public bool VerifyUser(Customer customer, Guid guid)
        {
            if (this.accountDirectory.ContainsKey(customer))
            {
                if (this.accountDirectory[customer].ContainsKey(guid))
                {
                    return true;
                }
                throw new KeyNotFoundException($"KEY: {guid} was not found in the dictionary");
            }
            throw new KeyNotFoundException($"Key: {customer} was not found in the dictionary");
        }

        public bool AcceptOverdraft(Customer customer, Guid guid)
        {
            bool userIsValid = VerifyUser(customer, guid);
            if (!userIsValid) { return false; }
                                
            IOverdraft? overdraft = overdraftDirectory.FirstOrDefault(o => o.guid == guid);
            if (overdraft != null)
            {
                bool withdrawOK = Withdraw(overdraft.guid, overdraft.amount, overdraft.customer);  
                if (withdrawOK) 
                {
                    this.overdraftDirectory.Remove(overdraft);
                    return true; 

                }
                return false;
            }
            throw new KeyNotFoundException($"Bank account with guid: {guid}, was not found");                                   
        }

        public bool RejectOverdraft(Customer customer, Guid guid)
        {
            bool userIsValid = VerifyUser(customer, guid);
            if (!userIsValid) { return false; }
            IOverdraft? overdraft = overdraftDirectory.FirstOrDefault(o => o.guid == guid);
            if (overdraft != null)
            {               
                this.overdraftDirectory.Remove(overdraft);
                return true;
            }
            throw new KeyNotFoundException($"Bank account with guid: {guid}, was not found");
        }

        public bool CreateCurrentAccount(Customer customer, out Guid accountNumber)
        {
            try
            {
                accountNumber = new Guid();
                Branch branch = new Branch()
                {
                    _name = Branches.California,
                    _location = ""
                };
                CurrentAccountEX currentAccount = new CurrentAccountEX(branch);
                bool userExists = this.accountDirectory.ContainsKey(customer);

                if (userExists)
                {
                    accountDirectory[customer].Add(accountNumber, currentAccount);
                }
                else
                {
                    accountDirectory.Add(customer, new Dictionary<Guid, AccountEX>());
                    accountDirectory[customer].Add(accountNumber, currentAccount);
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
            bool userIsValid = VerifyUser(customer, guid);
            if (!userIsValid) { return false; }
            AccountEX account = this.accountDirectory[customer][guid];
            bool depositOK = account.Deposit(amount);
            return depositOK;
                                                     
        }

        public bool RequestOverdraft(Customer customer, Guid guid, double amount)
        {
            bool userIsValid = VerifyUser(customer, guid);
            if (!userIsValid) { return false; }                                        
            IOverdraft overdraft = new Overdraft()
            {
                customer = customer,
                guid = guid,
                amount = amount
            };
            this.overdraftDirectory.Add(overdraft);
            return true;                                                       
        }

        public bool Withdraw(Guid guid, double amount, Customer customer)
        {
            bool userIsValid = VerifyUser(customer, guid);
            if (!userIsValid) { return false; }
            AccountEX account = this.accountDirectory[customer][guid];
            bool withdrawOK = account.Withdraw(amount);
            return withdrawOK;                                                       
        }       
    }
}
