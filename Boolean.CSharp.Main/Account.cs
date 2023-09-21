using System.Globalization;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class Account : IAccount
    {
        public double Balance { get; private set; }
        private List<Transaction> transactionList = new List<Transaction>();

        public void Deposit(double amount, DateTime date)
        {
            Balance += amount;
            transactionList.Add(new Transaction(date, amount, 0, Balance));
        }

        public void Withdraw(double amount, DateTime date)
        {
            if (amount > Balance)
            {
                throw new ArgumentException("You don't have enough funds on account");
            }
            Balance -= amount;
            transactionList.Add(new Transaction(date, 0, amount, Balance));
        }

        public string PrintStatement()
        { // using https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture?view=net-7.0

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("date       || credit  || debit  || balance");

            foreach (var transaction in transactionList.OrderByDescending(t => t.Date))
            {
                string creditValue = (transaction.Credit > 0 ? transaction.Credit.ToString("F2", CultureInfo.InvariantCulture) : "").PadLeft(7);
                string debitValue = (transaction.Debit > 0 ? transaction.Debit.ToString("F2", CultureInfo.InvariantCulture) : "      ");
                string balanceValue = transaction.BalanceAtTransactionTime.ToString("F2", CultureInfo.InvariantCulture).PadLeft(7);
                sb.AppendLine($"{transaction.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)} || {creditValue} || {debitValue} || {balanceValue}");
            }

            return sb.ToString().TrimEnd('\r', '\n');
        }
    }
}
