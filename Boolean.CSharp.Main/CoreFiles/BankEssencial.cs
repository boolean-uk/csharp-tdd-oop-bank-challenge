using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.CoreFiles
{
    public enum AccountType
    {
        Savings,
        Current,
    }

    public enum StatementType
    {
        Deposit,
        Withdraw,
    }

    public struct Overdraft(Account account, double amount)
    {
        Guid AccountID { get; } = account.ID;
        public double RequestedAmount { get; } = amount;
        public bool IsAccepted { get; set; } = false;
    }

    public struct Transaction(AccountType accountType, double amount, double accountBalance)
    {
        public double Amount { get;  } = amount;
        public AccountType AccountType { get; } = accountType;
        /// <summary>
        /// The past balance of the users account at the time of the creation of the statement.
        /// </summary>
        public double balanceAtTransaction { get; } = accountBalance;

        public string Date { get; } = DateTime.Now.ToString("dd:mm:yyyy");
        public string Time { get; } = DateTime.Now.ToString("h:mm");
    }
}
