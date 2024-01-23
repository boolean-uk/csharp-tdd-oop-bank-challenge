using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account : IAccount
    {
        private List<ITransaction> _transactions = new List<ITransaction>();

        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);
            transaction.SetBalance(GetBalance());

        }

        public string GenerateBankStatement()
        {
            if (_transactions == null || !_transactions.Any())
                return "No transactions available.";

            StringBuilder statement = new StringBuilder();
            var orderedTransactions = _transactions.OrderByDescending(t => t.GetDetails().Item1).ToList();

            // Placeholder for maximum column widths
            int maxDateLen = "date".Length, maxAmountLen = "amount".Length, maxBalanceLen = "balance".Length;

            // Calculate maximum lengths
            foreach (var transaction in orderedTransactions)
            {
                var (date, amount, balance) = transaction.GetDetails();
                maxDateLen = Math.Max(maxDateLen, date.ToString().Length);
                maxAmountLen = Math.Max(maxAmountLen, $"{amount:0.00}".Length)+2;
                maxBalanceLen = Math.Max(maxBalanceLen, $"{balance:0.00}".Length);
            }

            // Dynamic format string based on max lengths
            string format = $"{{0,-{maxDateLen}}} || {{1,-{maxAmountLen}}} || {{2,-{maxBalanceLen}}}";

            // Adding the header with dynamic spacing
            statement.AppendLine(string.Format(format, "date", "amount", "balance"));

            foreach (var transaction in orderedTransactions)
            {
                var (date, amount, balance) = transaction.GetDetails();

                string dateString = date.ToString();
                string amountString = amount >= 0 ? $"{amount:0.00}  " : $"  {amount:0.00}";
                string balanceString = $"{balance:0.00}";

                // Adding the transaction line to the statement
                statement.AppendLine(string.Format(format, dateString, amountString, balanceString));
            }

            return statement.ToString().TrimEnd(); // To remove the last new line
        }


        public double GetBalance()
        {
            double balance = 0;

            balance += (_transactions.Sum(t => t.GetDetails().Item2));

            return balance;
        }
    }
}
