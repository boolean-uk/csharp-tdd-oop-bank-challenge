using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.AccountModel
{
    public class Account
    {
        public string Name;
        public double Balance;
        public int FreeWithdrawals;
        public List<Transaction> Transactions = new List<Transaction>();

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Deposit(string date, double amount)
        {
            Balance += amount;
            Transactions.Add(new Transaction() { Date = date, AmountChanged = amount, NewBalance = Balance });
        }

        public void Withdraw(double amount)
        {
            if((Balance - amount) < 0)
            {
                Console.WriteLine("You don't have enough to withdraw this amount.");
            } else
            {
                Balance -= amount;
                FreeWithdrawals--;
            }
        }

        public void Withdraw(string date, double amount)
        {
            if ((Balance - amount) < 0)
            {
                Console.WriteLine("You don't have enough to withdraw this amount.");
            }
            else
            {
                Balance -= amount;
                FreeWithdrawals--;
                Transactions.Add(new Transaction() { Date = date, AmountChanged = -amount, NewBalance = Balance });
            }
        }

        public string ShowHistory()
        {
            string result = "";

            foreach(Transaction t in Transactions)
            {
                if(result == "")
                {
                    if(t.AmountChanged > 0)
                    {
                        result += $"{t.Date} | +{String.Format("{0:.00}", t.AmountChanged)} | {String.Format("{0:.00}", t.NewBalance)}";
                    } else
                    {
                        result += $"{t.Date} | {String.Format("{0:.00}", t.AmountChanged)} | {String.Format("{0:.00}", t.NewBalance)}";
                    }
                    
                } else
                {
                    if (t.AmountChanged > 0)
                    {
                        result += $" , {t.Date} | +{String.Format("{0:.00}", t.AmountChanged)} | {String.Format("{0:.00}", t.NewBalance)}";
                    }
                    else
                    {
                        result += $" , {t.Date} | {String.Format("{0:.00}", t.AmountChanged)} | {String.Format("{0:.00}", t.NewBalance)}";
                    }
                }
                
            }

            return result;
        }
    }
}
