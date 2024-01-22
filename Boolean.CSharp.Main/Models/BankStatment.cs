using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Models.Accounts;

namespace Boolean.CSharp.Main.Models
{
    public class BankStatement
    {
        public Account Account { get; set; }

        public BankStatement(Account account)
        {
            Account = account;
        }

        public string GetStatement()
        {
            StringBuilder statementText = new StringBuilder();

            statementText.AppendFormat("{0,10} || {1,10} || {2,10} || {3,10}\n", "Date", "Credit", "Debit", "Balance");
            foreach (Transaction transaction in Account.Transactions)
            {
                statementText.AppendFormat("{0,10} || {1,10} || {2,10} || {3,10}\n",
                    transaction.Date.ToString("dd/MM/yyyy"),
                    transaction.Type == TransactionType.Credit ? transaction.Amount.ToString("0.00") : "",
                    transaction.Type == TransactionType.Debit ? transaction.Amount.ToString("0.00") : "",
                    Account.GetBalanceAfterTransaction(transaction).ToString("0.00")
                );
            }

            return statementText.ToString();
        }
    }
}
