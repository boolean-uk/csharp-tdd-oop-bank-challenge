using System.Globalization;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class Account : IAccount
    {
        private List<Transaction> transactionList = new List<Transaction>();

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

        public string PrintStatement()
        { // using https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture?view=net-7.0
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("date       || credit  || debit  || balance");
            List<Transaction> reversedTransactions = transactionList.OrderByDescending(t => t.Date).ToList();
            double runningBalance = 0;

            for (int i = reversedTransactions.Count - 1; i >= 0; i--)
            {
                var transaction = reversedTransactions[i];
                runningBalance += transaction.Credit;
                runningBalance -= transaction.Debit;
                string creditValue = (transaction.Credit > 0 ? transaction.Credit.ToString("F2", CultureInfo.InvariantCulture) : "").PadLeft(7);
                string debitValue = (transaction.Debit > 0 ? transaction.Debit.ToString("F2", CultureInfo.InvariantCulture) : "      ");
                sb.AppendLine($"{transaction.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)} || {creditValue} || {debitValue} || {runningBalance.ToString("F2", CultureInfo.InvariantCulture).PadLeft(7)}");
            }

            return sb.ToString().TrimEnd('\r', '\n');
        }
    }
}
