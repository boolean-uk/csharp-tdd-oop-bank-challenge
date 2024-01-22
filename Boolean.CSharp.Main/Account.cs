using System.Globalization;
using System.Text;
using static Boolean.CSharp.Main.AllEnums;

namespace Boolean.CSharp.Main
{
    public class Account : IAccount
    {
        private List<Transaction> transactionList = new List<Transaction>();
        public Branches Branch { get; private set; }
        public double OverdraftLimit { get; private set; } = 0;
        public OverdraftStatus OverdraftStatus { get; private set; } = OverdraftStatus.None;
        public User AccountHolder { get; private set; }

        public Account(Branches branch, User accountHolder)
        {
            this.Branch = branch;
            this.AccountHolder = accountHolder;

        }

        public double GetBalance()
        {
            double balance = 0;
            foreach (var transaction in transactionList)
            {
                balance += transaction.Credit - transaction.Debit;
            }
            return balance;
        }

        public void Deposit(double amount, DateTime date)
        {
            transactionList.Add(new Transaction(date, amount, 0));
        }

        public void Withdraw(double amount, DateTime date)
        {
            if (amount > GetBalance())
            {
                throw new ArgumentException("You don't have enough funds on account");
            }
            transactionList.Add(new Transaction(date, 0, amount));
        }
        public void RequestOverdraft(double amount)
        {
            if (amount > 0)
            {
                OverdraftLimit = amount;
                OverdraftStatus = OverdraftStatus.Requested;
            }
            else
            {
                throw new ArgumentException("Overdraft request needs to be greater than 0");
            }
        }
        public void ApproveOverdraft()
        {
            if (OverdraftStatus == OverdraftStatus.Requested)
            {
                OverdraftStatus = OverdraftStatus.Approved;
            }
            else
            {
                throw new InvalidOperationException("There's no pending overdraft request, no approval possible");
            }
        }
        public void RejectOverdraft()
        {
            if (OverdraftStatus == OverdraftStatus.Requested)
            {
                OverdraftLimit = 0;
                OverdraftStatus = OverdraftStatus.Rejected;
            }
            else
            {
                throw new InvalidOperationException("There's no pending overdraft request, no rejection possible");
            }
        }

        public string PrintStatement()
        { // using https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture?view=net-7.0
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("date       || credit  || debit  || balance");
            List<Transaction> reversedTransactions = transactionList.OrderByDescending(t => t.Date).ToList();
            double runningBalance = GetBalance();

            for (int i = 0; i < reversedTransactions.Count; i++)
            {
                var transaction = reversedTransactions[i];
                string creditValue = (transaction.Credit > 0 ? transaction.Credit.ToString("F2", CultureInfo.InvariantCulture) : "").PadLeft(7);
                string debitValue = (transaction.Debit > 0 ? transaction.Debit.ToString("F2", CultureInfo.InvariantCulture) : "      ");
                sb.AppendLine($"{transaction.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)} || {creditValue} || {debitValue} || {runningBalance.ToString("F2", CultureInfo.InvariantCulture).PadLeft(7)}");
                runningBalance -= transaction.Credit;
                runningBalance += transaction.Debit;
            }
            return sb.ToString().TrimEnd('\r', '\n');
        }
    }
}
