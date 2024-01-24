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

        public string PhoneNumber { get { return _mobilePhone.PhoneNumber; } }


        public bool AddPhone(MobilePhone mobilePhone)
        {
            if(mobilePhone == null) return false;

            _mobilePhone = mobilePhone;
            return true;
        }

        public Account CreateAccount(Bank bank, AccountType accountType)
        {
            Account acc = bank.CreateAccount(this, accountType, _mobilePhone);
            if (acc == null || acc == default(Account))
                return null;


            accounts.Add(acc);
            return acc;
        }
    }
}
