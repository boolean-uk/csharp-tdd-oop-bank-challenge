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

        private IMessenger messenger = new ConsoleMessenger();
        public List<Transaction> transactions { get; private set; } = new List<Transaction>();

        public double Overdraft { get; private set; } = 0d;
        private (OverdraftStatus status, double amount) pendingOverdraft = (OverdraftStatus.Default, 0d);

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
            if (amount > Savings() + Overdraft) return false;
            Transaction transaction = new Transaction(DateTime.Now, -amount,  Savings() - amount);
            transactions.Add(transaction);
            return true;
        }

        public bool Withdraw(double amount, DateTime time)
        {
            if (amount > Savings() + Overdraft) return false;
            Transaction transaction = new Transaction(time, -amount, Savings() - amount);
            transactions.Add(transaction);
            return true;
        }

        public void CreateBankStatement()
        {
            string statement = "";
            statement += 
                String.Format("{0, -11}|| {1, -10}|| {2, -10}|| {3, -10}\n", 
                              "date", "credit", "debit", "balance"
                             );
            foreach( Transaction elm in transactions)
            {
                string[] val = { "", "" };
                if (elm.isCredit) val[0] = elm.Amount;
                else val[1] = elm.Amount;
                statement +=
                    String.Format("{0, -11}||{1, 10} ||{2, 10} || {3, -10}\n", 
                    elm.Time, val[0], val[1], elm.Balance);
            }

            messenger.send(statement);
        }

        public bool RequestOverdraft(double amount)
        {
            if (pendingOverdraft.status == OverdraftStatus.Default)
            {
                pendingOverdraft.status = OverdraftStatus.Requested;
                pendingOverdraft.amount = amount;
                return true;
            }
            return false;
        }


        public bool AcceptOverdraft()
        {
            if (pendingOverdraft.status == OverdraftStatus.Requested)
            {
                Overdraft = pendingOverdraft.amount;
                pendingOverdraft.status = OverdraftStatus.Default;
                return true;
            }
            return false;
        }

        public bool RejectOverdraft()
        {
            if (pendingOverdraft.status == OverdraftStatus.Requested)
            {
                pendingOverdraft.status = OverdraftStatus.Default;
                pendingOverdraft.amount = 0;
                return true;
            }
            return false;
        }
    }
}
