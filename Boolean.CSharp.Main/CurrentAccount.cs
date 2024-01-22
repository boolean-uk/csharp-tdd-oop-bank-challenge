using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main;


namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {
        public List<Transaction> Transactions { get; } = new List<Transaction>();
        public CurrentAccount()
        {
        }

        public override bool Deposit(decimal amount)
        {
            return base.Deposit(amount);
            
        }

        public override bool Withdraw(decimal amount)
        {
            return base.Withdraw(amount);
         
        }

        public override string GenerateStatement()
        {
            return base.GenerateStatement();
        }

        public override decimal GetBalance()
        {
            return base.GetBalance();
        }


        //Extension

        public override bool setBranch(string Branch)
        {
            return base.setBranch(Branch);
        }


        public override void sendToPhone(string phoneNumber)
        {
            base.sendToPhone(phoneNumber);
        }
    }


}
