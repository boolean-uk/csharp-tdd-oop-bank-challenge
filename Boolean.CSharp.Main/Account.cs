using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Account
    {
        private string name;
        private List<Transaction> transactions;
        private float balance;
        public Account(string name) 
        {
            this.name = name;
            transactions = new List<Transaction>();
        }

        public bool deposit(float amount, string date)
        {
            balance += amount;
            Transaction trans = new Transaction(balance, date, amount, "credit");
            transactions.Add(trans);
            

            return true;
        }
        public bool withdraw(float amount, string date)
        {
            balance -= amount;
            Transaction trans = new Transaction(balance, date, amount, "debit");
            transactions.Add(trans);
            

            return true;
        }

        public List<string> statement()
        {
            List<string> result = new List<string>();

            if(transactions.Count > 0)
            {
                result.Add("date       || credit  || debit  || balance");

                foreach(Transaction trans in transactions)
                {

                    if (trans.getType() == "credit")
                    {
                        result.Add(trans.getDate() + " || " + trans.getChange().ToString("0.00") + " ||        || " + trans.getCurrentBalance().ToString("0.00"));
                    }
                    else
                    {
                        result.Add(trans.getDate() + " ||        || " + trans.getChange().ToString("0.00") + " || " + trans.getCurrentBalance().ToString("0.00"));
                    }


                    
                }
            }


            return result;
        }

        public string getName()
        {
            return name;
        }

    }
}
