using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        private ICustomer _bank;

        private List<Account> _accounts;

        private string _branch;
        public Customer( ICustomer bank, string branch)
        {
            _bank = bank;
            _accounts = new List<Account>();
            _branch = branch;
        }

        public void createCurrentAccount()
        {
            Account act = _bank.createCurrentAccount(this, _branch);
            _accounts.Add(act);
        }

        public void createSavingsAccount()
        {
            Account act = _bank.createSavingsAccount(this, _branch);
            _accounts.Add(act);
        }
        public void deposit(float amount, Account account)
        {
            Transactions transaction = new Transactions(amount, account);
            account.transaction(transaction);
        }

        public void requestOverDraft(Account ca)
        {
            if(ca.customer == this)
            {
                _bank.requestsOverDraft(ca);
            }
        }

        public void withDraw(float amount, Account account)
        {
            Transactions transaction = new Transactions(amount * (-1), account);
            account.transaction(transaction);
        }
    }
}
