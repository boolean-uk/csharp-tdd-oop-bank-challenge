using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        private int customers;
        private double overDraftLimit;
        private List<Account> bankAccounts = new List<Account>();

        public Bank() 
        {
            customers = -1;
            overDraftLimit = 0;
        }

        public int CreateAccount(int customerId, IBranch branch, bool savingsAccount)
        {
            // an account number will start with the customer ID and followed by the account number
            if(customerId > customers || customers < 0)
            {
                return -1; // this customer has not been given out yet or doesn't exist
            }
            int accountNum = 0;
            for(int i = 0; i < bankAccounts.Count; i++)
            {
                if (bankAccounts[i].customerId == customerId)
                {
                     accountNum++;
                }
            }

            if(savingsAccount)
            {
                Savings newAccount = new Savings(customerId, accountNum, branch);
                bankAccounts.Add(newAccount);
                return accountNum;
            }
            else
            {
                Current newAccount = new Current(customerId, accountNum, branch);
                bankAccounts.Add(newAccount);
                return accountNum;
            }
        }

        public bool CreateCustomer(Customer customer)
        {
            if(customer.customerId == -1)
            {
                //new customer
                customers++;
                customer.customerId = customers;
                return true;
            }
            return false;
        }

        public double GetOverdraftLimit()
        {
            return overDraftLimit; 
        }

       
        public void RequestDeposit(int customerId, double funds, int bankAccount, bool overdraw)
        {
            throw new NotImplementedException();
        }

        public void SetOverdraftLimit(Manager manager)
        {
            overDraftLimit = manager.overDraftLimit;
        }

        public string RequestBankStatement(int customerId, int accountNumber)
        {
            foreach (var account in bankAccounts)
            {
                if(account.customerId == customerId && account.accountNumber == accountNumber)
                {
                    return account.GenerateStatement();
                }
            }
            return "Account not found";
        }
        
    }
}
