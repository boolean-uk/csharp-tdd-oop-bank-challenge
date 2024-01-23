using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transactions
{
    public interface IOverdraftRequest
    {

        /// <summary>
        /// Retrieve the Customer object that requested the new overdraft limit
        /// </summary>
        /// <returns> Customer - the creator of the IOverdraftReuest </returns>
        Customer GetRequester();

        /// <summary>
        /// Retrieve the desired new Overdraft limit
        /// </summary>
        /// <returns>decimal - the requested new overdraft amount</returns>
        decimal GetRequestOverdraftLimit();

        /// <summary>
        /// Retrieve the time and date the overdraft request was submitted
        /// </summary>
        /// <returns>DateTime - DateTime object of the IOverdraftRequest creation </returns>
        DateTime GetRequestDate();

        /// <summary>
        /// Retrieve the IAccount object the overdraft request pertains to
        /// </summary>
        /// <returns>IAccount - the object that the overdraft request applies to</returns>
        IAccount GetOverdraftRequestAccount();
    }
}
