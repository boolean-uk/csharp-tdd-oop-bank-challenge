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
    public enum OverdraftState
    {
        Pending,
        Accepted,
        Rejected
    }

    public class Overdraft(Guid accountID, double amount)
    {
        Guid AccountID { get; } = accountID;
        public double RequestedAmount { get; } = amount;
        public OverdraftState OverdraftState { get; set; } = OverdraftState.Pending;
        public DateTime DateTime { get; } = DateTime.Now;
    }

    public struct Transaction(StatementType statementType, double amount, double accountBalance)
    {
        Guid ID = Guid.NewGuid();
        public double Amount { get; } = amount;
        public StatementType StatementType { get; } = statementType;
        /// <summary>
        /// The past balance of the users account at the time of the creation of the statement.
        /// </summary>
        public double balanceAtTransaction { get; } = accountBalance;

        public DateTime dateTime { get; } = DateTime.Now;
    }
}
