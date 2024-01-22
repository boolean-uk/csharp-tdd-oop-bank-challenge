using Boolean.CSharp.Main.Accounts.Constants;
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
        Guid _AccId { get; set; }   // A uniq ID of an account
        bool _IsAccActive { get; set; }     //Is the account active?
        Branches _Branch { get; }   //Branch of the account

        /// <summary>
        /// A method to get the balance of the account.
        /// </summary>
        /// <returns> The balance </returns>
        double getBlance();

        /// <summary>
        /// A method to deposit money into the account.
        /// </summary>
        /// <param name="transaction"> Object of transaction class</param>
        void Deposit(Transaction transaction);

        /// <summary>
        /// A method to withdraw money from the account.
        /// </summary>
        /// <param name="transaction">Object of transaction class</param>
        void Withdraw(Transaction transaction);


        /// <summary>
        /// A method to get a list of transactions
        /// </summary>
        /// <returns>List of transactions</returns>
        List<Transaction> getOverview();

        /// <summary>
        /// A method to get the account status.
        /// </summary>
        /// <returns>Return false or true based on the status of the account</returns>
        bool getAccountStatus();

        /// <summary>
        /// A method to write out the statement of the account.
        /// </summary>
        string writeStatement();

        /// <summary>
        /// A method to send overdraft request
        /// </summary>
        /// <param name="request"></param>
        void RequestOverdraft(Transaction request, Manager custommerAdvisor);
        public List<Transaction> getRequest();
    }
}
