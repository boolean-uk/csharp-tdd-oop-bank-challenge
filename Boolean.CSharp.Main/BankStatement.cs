using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BankingApp.Boolean.CSharp.Main
{
    public static class BankStatement
    {
        public static string PrintStatement(List<Transaction> transactions)
        {
            var bankStatement = "date || credit || debit || balance \n";
            foreach (var transaction in transactions.OrderByDescending(x => x.Date))
            {
                string transactionInfo = $"{transaction.Date} || {(transaction.Type == TransactionType.Deposit ? transaction.Amount : "")} || {(transaction.Type == TransactionType.Withdraw ? transaction.Amount : "")} || {transaction.BalanceAfterTransaction}\n";
                bankStatement += transactionInfo;
                
            }
            return bankStatement;
        }
    }
}
