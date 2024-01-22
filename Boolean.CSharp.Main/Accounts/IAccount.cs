using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public interface IAccount
    {

        bool Deposit(decimal amount);

        decimal Withdraw(decimal amount);

        decimal GetBalance();

        void PrintBankStatement(DateTime start, DateTime end);

        bool AddUserToAccount(IUser user);
    }
}
