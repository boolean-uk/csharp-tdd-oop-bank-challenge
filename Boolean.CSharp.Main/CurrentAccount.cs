using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class CurrentAccount: IAccount
    {
        public string account_id { get ; set ; }
        public int balance { get ; set ; }
        public Account Account_type { get ; set ; }
        public Branch Branch { get ; set ; }
        public Overdraft Overdraft { get ; set ; }
        public int overdraft_amount { get ; set ; }

        public void Create_Account(string account_id, int balance, string account_type, string branch, string overdraft)
        {
            this.account_id = account_id;
            this.balance = balance;
            this.Account_type = Account.Current;
            this.Branch = default;
            this.Overdraft = default;
        }

        public void Request_Overdraft(Overdraft overdraft, int amount)
        {
            this.Overdraft = (Overdraft) overdraft;
            this.overdraft_amount = amount;
        }
    }
}
