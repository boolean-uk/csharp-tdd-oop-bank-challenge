using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Customer
    {
        private IDictionary<string, Account> _myBankAccounts;

        public Customer ()
        {
            _myBankAccounts = new Dictionary<string, Account> ();
        }

        public IDictionary<string, Account> MyBankAccounts { get { return _myBankAccounts; } }


        public void CreateAccount(string accountID)
        {
            Account account = new Account(accountID);

            _myBankAccounts.Add(accountID, account);
        }

    }
}
