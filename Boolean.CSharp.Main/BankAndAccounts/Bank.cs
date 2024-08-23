using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Branches;
using Boolean.CSharp.Main.Customers;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.BankAndAccounts
{
    public class Bank
    {
        private List<Account> _accounts; //Dictionary list of customer and accounts
        public Bank()
        {
            this._accounts = new List<Account>();
        }
        public bool CreateCurrent(ICustomer customer, IBranch branch)
        {
            //Check if this customer already has a current account
            foreach (var account in this._accounts)
            {
                if(account.owner.GetName() == customer.GetName() && account.type)
                {
                    return false; //Customer already has a current account.
                }
            }

            //Create a current account
            this._accounts.Add(new Current(customer, branch));
            return true;
        }

        public bool CreateSaving(ICustomer customer, IBranch branch)
        {
            //Check if this customer already has a savings account
            foreach(var account in this._accounts)
            {
                if(account.owner.GetName() == customer.GetName() && !account.type)
                {
                    return false; //Customer already has a savings account
                }
            }

            //Create a savings account
            this._accounts.Add(new Saving(customer, branch));
            return true;
        }

        public string GetTransactionHistory(ICustomer customer, bool type)
        {
            foreach (Account account in this._accounts)
            {
                if (account.owner.GetName() == customer.GetName() && account.type == type)
                {
                    return account.Transactions();
                }
            }
            return string.Empty;
        }

        public void HandleDeposit(ICustomer customer, decimal amount, bool type)
        {
            foreach(Account account in this._accounts)
            {
                if(account.owner.GetName() == customer.GetName() && account.type == type)
                {
                    account.Deposit(amount);
                }
            }
        }

        public bool HandleWithdraw(ICustomer customer, decimal amount, bool type)
        {
            foreach (Account account in this._accounts)
            {
                if (account.owner.GetName() == customer.GetName() && account.type == type)
                {
                    return account.Withdraw(amount);
                }
            }
            return false;
        }
    }
}
