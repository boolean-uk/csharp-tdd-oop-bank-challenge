using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class BankStatementBuilder
    {
        public string BuildStatement(List<Transaction> transactions)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("date       || credit  || debit  || balance");

            foreach(Transaction transaction in transactions)
            {
                string isCredit = transaction.TypeOfTransaction == Transaction.TransactionType.Credit ? transaction.Amount.ToString() : "";

                string isDebit = transaction.TypeOfTransaction == Transaction.TransactionType.Debit ? transaction.Amount.ToString() : "";

                stringBuilder.AppendLine($"{transaction.Time.Day}/{transaction.Time.Month}/{transaction.Time.Year} || {isCredit} || {isDebit} || {FormatAmount(transaction.Balance)}");
            }

            return stringBuilder.ToString();
        }

        private string FormatAmount(float amount)
        {
            return amount == 0 ? "" : amount.ToString("F2");
        }
    }
}
