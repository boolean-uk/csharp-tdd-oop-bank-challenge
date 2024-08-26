using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class SavingsAccount : IAccount
    {
        public string AccountNumber { get;}

        public AccountType Type {  get; } = AccountType.Savings;

        public SavingsAccount(string accountNumber)
        {
            AccountNumber = accountNumber;
        }


        public void deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
