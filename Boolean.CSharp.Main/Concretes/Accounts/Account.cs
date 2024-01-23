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
            StringBuilder statement = new StringBuilder();
            var orderedTransactions = _transactions.OrderByDescending(t => t.GetDetails().Item1).ToList();

            // Adding the header
            statement.AppendLine("date       || amount || balance");

            foreach (var transaction in orderedTransactions)
            {
                var (date, amount, balance) = transaction.GetDetails();

                // Formatting the date and amount as per requirements
                string dateString = date.ToString();
                string amountString = amount >= 0 ? $"  {amount:0.00}" : $"{amount:0.00}";
                string balanceString = $"{balance:0.00}";

                // Adding the transaction line to the statement
                statement.AppendLine($"{dateString} || {amountString} || {balanceString}");
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
