using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Core
{


    public abstract class AAccount
    {
        public List<Transaction> transactions { get; private set; } = new List<Transaction>();

        public OverdraftStatus Overdraft { get; private set; } = OverdraftStatus.Default;

        public Branch Branch { get; private set; }

        public AAccount() {
            Branch = Branch.Yorkshire;
        }

        public AAccount(Branch bank)
        {
            this.Branch = bank;
        }

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
            if (amount > Savings() & Overdraft != OverdraftStatus.Accepted) return false;
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

        public bool RequestOverdraft()
        {
            if ( Overdraft == OverdraftStatus.Default)
            {
                Overdraft = OverdraftStatus.Requested;
                return true;
            }
            return false;
        }


        public bool AcceptOverdraft()
        {
            if ( Overdraft == OverdraftStatus.Requested)
            {
                Overdraft = OverdraftStatus.Accepted;
                return true;
            }
            return false;
        }

        public bool RejectOverdraft()
        {
            if (Overdraft == OverdraftStatus.Requested)
            {
                Overdraft = OverdraftStatus.Rejected;
                return true;
            }
            return false;
        }
    }
}
