using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public abstract class Customer : IUser
    {
        private List<IAccount> _associatedAccounts = new List<IAccount>();
        private string _name;

        public Customer(string name)
        {
            _name = name;
        }

        public List<IAccount> GetAccounts()
        {
            return new List<IAccount>(this._associatedAccounts);
        }

        public string GetName()
        {
            return _name;
        }

        public bool OpenNewAccount(AccountType accountType) 
        {
            IAccount newAcc;
            int val1;
            int val2;
            if (accountType == AccountType.General)
            {
                newAcc = new GeneralAccount();
            }
            else 
            {
                newAcc = new SavingsAccount();
            }
            val1 = _associatedAccounts.Count;
            _associatedAccounts.Add(newAcc);
            val2 = _associatedAccounts.Count;
            return val1 < val2;
        }
    }
}
