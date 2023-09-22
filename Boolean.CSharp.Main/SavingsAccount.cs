using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class SavingsAccount : IAccount
    {
        public string account_id { get ; set ; }
        public int balance { get ; set ; }
        public Account account_type { get ; set ; }

        public void Create_Account(string account_id, int balance, string account_type)
        {
            this.account_id = account_id;
            this.balance = balance;
            this.account_type = Account.Savings;
        }
    }
}
