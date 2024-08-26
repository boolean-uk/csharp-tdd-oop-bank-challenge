using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        Account ?account;

        public List<Account> accounts {  get; set; } = new List<Account>();

        public bool CreateAccount(AccountType accountType)
        {
            if (accountType == AccountType.Current)
            {
                account = new CurrentAccount();
                accounts.Add(account);
                return true;
            } 
            else if (accountType == AccountType.Savings) 
            {
                account = new SavingsAccount();
                accounts.Add(account);
                return true;
            }

            return false;

        } 
    }
}
