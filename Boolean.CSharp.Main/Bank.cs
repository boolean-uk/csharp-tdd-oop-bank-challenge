using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        public List<Account> accountList;

        public Bank()
        {
            accountList = new List<Account>();
        }

        public bool CreateCurrentAccount(string accountNumber)
        {
            foreach (Account account in accountList)
            {
                if (account.AccountNumber.Equals(accountNumber))
                {
                    return false;
                }
            }
            accountList.Add(new CurrentAccount(accountNumber, 0));
            return true;
        }

        public bool CreateSavingAccount(string accountNumber)
        {
            foreach (Account account in accountList)
            {
                if (account.AccountNumber.Equals(accountNumber))
                {
                    return false;
                }
            }
            accountList.Add(new SavingAccount(accountNumber, 0));
            return true;
        }

    }
}
