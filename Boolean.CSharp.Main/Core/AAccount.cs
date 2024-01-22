using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Core
{
    public enum Banks { Yorkshire, Berkshire, Lincolnshire, Worcestershire, 
        Shropshire, Oxforshire, Warwickshire, Cambridgeshire, Derbyshire, Gloucestershire, 
        Lancashire, Nottinghamshire, Staffordshire, Buckinghamshire, Wiltshire, Bedfordshire, 
        Northamptonshire}

    public abstract class AAccount
    {
        public List<Transaction> transactions { get; private set; } = new List<Transaction>();
        public double Savings()
        {
            if (transactions.Count == 0) return 0d;
            return transactions.Last().balance;
        }

        public bool Deposit(double amount)
        {
            Transaction transaction = new Transaction(DateTime.Now, amount, Savings() + amount);
            transactions.Add(transaction);
            return true;
        }

        public bool Deposit(double amount, DateTime date)
        {
            Transaction transaction = new Transaction(date, amount, Savings() + amount);
            transactions.Add(transaction);
            return true;
        }

        public bool Withdraw(double amount)
        {
            if (amount > Savings()) return false;
            Transaction transaction = new Transaction(DateTime.Now, -amount,  Savings() - amount);
            transactions.Add(transaction);
            return true;
        }

        public bool Withdraw(double amount, DateTime time)
        {
            if (amount > Savings()) return false;
            Transaction transaction = new Transaction(time, -amount, Savings() - amount);
            transactions.Add(transaction);
            return true;
        }

        public void CreateBankStatement()
        {
            Console.WriteLine("{0, -11}|| {1, -10}|| {2, -10}|| {3, -10}", "date", "credit", "debit", "balance");
            foreach( Transaction elm in transactions)
            {
                string[] val = { "", "" };
                if (elm.isCredit) val[0] = elm.Amount;
                else val[1] = elm.Amount;
                Console.WriteLine("{0, -11}||{1, 10} ||{2, 10} || {3, -10}", elm.Time, val[0], val[1], elm.Balance);
            }
        }
    }
}
