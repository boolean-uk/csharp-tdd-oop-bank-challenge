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

       
        public bool RequestDeposit(Customer customer, double funds, int bankAccount)
        {
            if(funds > customer.funds)
            {
                return false; // not enough funds to make deposit
            }
            foreach (var account in bankAccounts)
            {
                if (account.customerId == customer.customerId && account.accountNumber == bankAccount)
                {
                    // account found! Time for deposit
                    account.Deposit(funds);
                    customer.funds -= funds; //well, you dont get to deposit and keep the money. You gave it to the bank
                    return true;
                }
            }



            return false; // account does not exist
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

        public bool RequestWithdraw(Customer customer, double funds, int accountNumber, bool overdraw)
        {
            Account acc = null;
            foreach (var account in bankAccounts)
            {
                if (account.customerId == customer.customerId && account.accountNumber == accountNumber)
                {
                    // account found!
                    acc = account;
                }
            }
            if (acc == null)
            {
                //account not found
                return false;
            }
            if (overdraw)
            {
                if (acc.Balance() < funds - overDraftLimit)
                {
                    // even with overdraw, it's not enough money in the account for this type of withdrawal
                    return false;
                }
            }
            else
            {
                if (acc.Balance() < funds)
                {
                    //not enough funds in account and this is no overdraw
                    return false;
                }
            }

            //withdraw is fine
            customer.funds += funds;
            acc.Withdraw(funds);
            return true;
        }
    }
}
