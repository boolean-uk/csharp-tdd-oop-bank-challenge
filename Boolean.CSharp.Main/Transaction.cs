using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Type;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {

        DateTime data;
        double amount;
        double currentBalance;

        public Transaction(DateTime data, double amount, double currentBalance, string debitOrCredit)
        {
            this.data = data;
            this.amount = amount;
            this.debitOrCredit = debitOrCredit;
            this.currentBalance = currentBalance;
        }
        public DateTime getData()
        {
            return data;
        }

        public void setData(DateTime data)
        {
            this.data = data;
        }

        public double getAmount()
        {
            return amount;
        }

        public void setAmount(double amount)
        {
            this.amount = amount;
        }

        public double getCurrentBalance()
        {
            return currentBalance;
        }

        public void setCurrentBalance(double currentBalance)
        {
            this.currentBalance = currentBalance;
        }

        public string getDebitOrCredit()
        {
            return debitOrCredit;
        }

        public void setDebitOrCredit(string debitOrCredit)
        {
            this.debitOrCredit = debitOrCredit;
        }

        string debitOrCredit;


    }
}
