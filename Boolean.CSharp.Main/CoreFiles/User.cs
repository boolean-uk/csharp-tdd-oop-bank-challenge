using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Other;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.CoreFiles
{
    public abstract class User
    {
        public double Money = 0;
        public List<Account> accounts = new List<Account>();
        protected MobilePhone _mobilePhone = new MobilePhone();

        public Account CreateAccount(AccountType accountType)
        {
            Account newAccount;

            switch (accountType)
            {
                case AccountType.Current:
                    newAccount = new AccountCurrent(this, (_mobilePhone != null) ? _mobilePhone : null);
                    accounts.Add(newAccount);
                    return newAccount;
                case AccountType.Savings:
                    newAccount = new AccountSavings(this, (_mobilePhone != null) ? _mobilePhone : null);
                    accounts.Add(newAccount);
                    return newAccount;

                default:
                    return null;
            }
        }

        public bool AddPhone(MobilePhone mobilePhone)
        {
            if(mobilePhone == null) return false;

            _mobilePhone = mobilePhone;
            return true;
        }
    }
}
