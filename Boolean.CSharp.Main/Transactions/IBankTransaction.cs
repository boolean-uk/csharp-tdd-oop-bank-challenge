using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transactions
{
    public interface IBankTransaction
    {

        /// <inheritdoc cref="Accounts.IAccount.PrintBankStatement(DateTime, DateTime, bool)"/>
        string PrintTransactions(DateTime start, DateTime end);

        /// <summary>
        /// Append a transaction of type "Deposity" into the transaction history
        /// </summary>
        /// <param name="amount"> decimal - The amount to be deposited </param>
        /// <returns> bool - True the transaction was appended to the transaction history, false otherwise </returns>
        bool AddDepositTransaction(decimal amount);

        /// <summary>
        /// Append a transaction of type "Withdraw" into the transaction history
        /// </summary>
        /// <param name="amount"> decimal - The amount to be withdrawn </param>
        /// <returns> bool - True the transaction was appended to the transaction history, false otherwise </returns>
        bool AddWithdrawTransaction(decimal amount);

        /// <summary>
        /// Calculate the current account balance by iterating through the entire transaction history of the account
        /// </summary>
        /// <returns> decimal - current account balance </returns>
        decimal CalculateAccountBalance();
    }
}
