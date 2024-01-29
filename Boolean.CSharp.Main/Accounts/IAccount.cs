using Boolean.CSharp.Main.Branch;
using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public interface IAccount
    {
        /// <summary>
        /// Attempt to deposit an amount of money to the IAccount object.
        /// </summary>
        /// <param name="amount"> Amount to be deposited</param>
        /// <returns>bool - True if the amount was successfully deposited, otherwise false</returns>
        bool Deposit(decimal amount);

        /// <summary>
        /// Attempt to withdraw an amount of money from the IAccount object.
        /// </summary>
        /// <param name="amount"> Amount to be withdrawn</param>
        /// <returns>decimal - the amount of money withdrawn from the account. 0 is returned if the withdrawal failed</returns>
        decimal Withdraw(decimal amount);

        /// <summary>
        /// Retrieve the IAccount current balance
        /// </summary>
        /// <returns>decimal - Amount of money contained in the IAccount </returns>
        decimal GetBalance();

        /// <summary>
        /// Print a itemized statement to the console of every transaction on the account between the provided start and end times.
        /// </summary>
        /// <param name="start">DateTime object representing the time for the earliest transactions to print</param>
        /// <param name="end">DateTime object representing the time for the latest transactions to print</param>
        /// <param name="sendSMS"> bool - Switch if the statement should be sent by sms</param>
        void PrintBankStatement(DateTime start, DateTime end, bool sendSMS = false);

        /// <summary>
        /// Add a IUser object to the accounts list of associated Users
        /// </summary>
        /// <param name="user">IUser object to be added to the account</param>
        /// <returns>bool - true if the user was successfully added to the IAccount, otherwise false</returns>
        bool AddUserToAccount(IUser user);

        /// <summary>
        /// Attempt to set the overdraw limit for the IAccount. NB: Each account type may handle overdraw differently.
        /// </summary>
        /// <param name="limit"> The desired overdraw limit</param>
        /// <param name="user">The user that attempt to make the overdraw limit change. Used to verify permissions </param>
        /// <returns> Decimal of the new overdraw limit on the account</returns>
        decimal SetOverdrawLimit(decimal limit, IUser user);
    }
}
