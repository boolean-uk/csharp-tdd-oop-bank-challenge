using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account
    {
        public int customerId;
        public int accountNumber;
        public IBranch branch;
        private List<string> history = new List<string>();
        protected Account(int customerId, int accountNumber, IBranch branch)
        {
            this.customerId = customerId;   
            this.accountNumber = accountNumber;
            this.branch = branch;
        }

        public void Deposit(double funds)
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            double balance = funds;
            if(history.Count != 0)//not first action
            {
                balance += Balance();
            }
            history.Add(date + " || " + Math.Round(funds, 2) + " ||        || " + balance);
        }

        public double Balance()
        {
            string s = history[history.Count - 1];
            int lastIndex = s.LastIndexOf("|| ");
            string b = s.Substring(lastIndex + 3);
            return Convert.ToDouble(b);
        }
    }
}
