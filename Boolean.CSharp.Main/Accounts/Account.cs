using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account
    {
        TransactionManager _transactions = new TransactionManager();
        List<IUser> authorizedUsers = new List<IUser>();
        private decimal _balance = 0m;

        public bool Deposit(decimal amount) 
        {
            throw new NotImplementedException();
        }

        public decimal Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }

        public decimal GetBalance() 
        {
            throw new NotImplementedException();
        }
    }
}
