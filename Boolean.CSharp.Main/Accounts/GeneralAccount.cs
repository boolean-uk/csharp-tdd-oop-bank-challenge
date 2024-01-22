using Boolean.CSharp.Main.Transactions;
using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class GeneralAccount : IAccount
    {
        IBankTransaction _transactions = new TransactionManager();
        List<IUser> authorizedUsers = new List<IUser>();
        private decimal _balance = 0m;

        public bool AddUserToAccount(IUser user)
        {
            throw new NotImplementedException();
        }

        public bool Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public decimal GetBalance()
        {
            throw new NotImplementedException();
        }

        public void PrintBankStatement(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public decimal Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
