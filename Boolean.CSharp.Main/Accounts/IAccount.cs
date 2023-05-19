using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Boolean.CSharp.Main.Accounts
{
    public interface IAccount
    {
        List<Transaction> Transactions { get; set; }
        decimal Balance { get; set; }
        Transaction Deposit(DateTime date, decimal amount);
        Transaction Withdraw(DateTime date, decimal amount);

        bool isSavingAccount { get; }
    }
}
