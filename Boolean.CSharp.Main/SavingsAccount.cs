using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class SavingsAccount : Account
    {
        private static int withdrawLimit = 4;
        public int FreeWithdrawals{ get; set; } = withdrawLimit;

        public override void Withdraw(double amount, bool overdraftApproval)
        {
            if (base.Balance < amount)
            {
                string addMessage = "";
                if (overdraftApproval) { addMessage = " - Savings accounts can never be overdrafted";  }
                throw new ArgumentException($"Insuficcinet funds! Balance: {base.Balance}{addMessage}");
            }
            else if(FreeWithdrawals < 1) { throw new ArgumentException($"You have excceded the limt of free withdrawals"); }
            else
            {
                
                base.Balance -= amount;

                DateTime date = DateTime.Today;
                Transaction withrawal = new Transaction(date, -1 * amount, Balance);
                Transactions.Add(withrawal);
                FreeWithdrawals--;
            }
        }

        public SavingsAccount(string accountnumber, string name, Roles role) : base(accountnumber, name, role) { }
    }
}
