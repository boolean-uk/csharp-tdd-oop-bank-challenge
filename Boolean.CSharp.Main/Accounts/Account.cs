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
            string spaceHelper = "";
            if (funds < 1000)
            {
                spaceHelper = " ";
            }
            string decimalHelper = "";
            if (!funds.ToString().Contains("."))// .00 must be added
            {
                decimalHelper = ".00";
            }
            string balanceHelper = "";
            if(!balance.ToString().Contains(".")) //.00 must be added
            {
                balanceHelper = ".00";
            }
            string balanceSpace = "";
            if (balance < 1000)// .00 must be added
            {
                balanceSpace = " ";
            }

            history.Add(date + " || " + Math.Round(funds, 2) + decimalHelper+ spaceHelper + " ||         || " + balance + balanceHelper + balanceSpace);
        }

        public double Balance()
        {
            string s = history[history.Count - 1];
            int lastIndex = s.LastIndexOf("|| ");
            string b = s.Substring(lastIndex + 3);
            b = b.Replace('.', ','); // because math apperently doesn't like . 
            return Convert.ToDouble(b);
        }

        public void Withdraw(double funds)
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            double balance = Balance();
            balance -= funds;

            string spaceHelper = "";
            if(funds < 1000)
            {
                spaceHelper = " ";
            }
            string decimalHelper = "";
            if(!funds.ToString().Contains("."))// .00
            {
                decimalHelper = ".00";
            }
            string balanceHelper = "";
            if (!balance.ToString().Contains(".")) //.00 must be added
            {
                balanceHelper = ".00";
            }
            string balanceSpace = "";
            if (balance < 1000)// .00 must be added
            {
                balanceSpace = " ";
            }



            history.Add(date + " ||         || " + Math.Round(funds, 2) + decimalHelper + spaceHelper + " || " + balance + balanceHelper+ balanceSpace);
        }
        //14/01/2012 ||         || 500.00 || 2500.00

        public string GenerateStatement()
        {
            string statement = "date       || credit  || debit   || balance\n";

            for (int i = history.Count - 1; i >= 0; i--)
            {
                statement += history[i].ToString() + "\n";
            }

            return statement;
        }
    }
}
