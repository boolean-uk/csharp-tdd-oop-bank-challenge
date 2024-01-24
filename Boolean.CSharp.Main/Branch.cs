using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Branch
    {
        public List<BankAccount> accounts { get; internal set; } = new List<BankAccount>();

        public void AddAccount(BankAccount bankAccount)
        {
            accounts.Add(bankAccount);
        }

        public void RemoveAccount(BankAccount account)
        {
            accounts.Remove(account);
        }
    }
}
