using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML.Voice;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : IAccount
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public Account Type { get; set; }
        public Branch Branch { get; set; }
        public Overdraft Overdraft { get; set; }
        public int overdraft_amount { get; set; }


        public void creatCurrentAccount(int accountId, decimal balance, string type, Branch branch, string overdraft)
        {
            this.AccountId = accountId;
            this.Balance = balance;
            this.Type = Account.Current;
            this.Branch = branch;
            this.Overdraft = default;
        }


        public void RequestOverdraft(Overdraft requestedOverdraft, int amount)
        {
            Overdraft = requestedOverdraft;
            overdraft_amount = amount;

        }
    }

    
}
      