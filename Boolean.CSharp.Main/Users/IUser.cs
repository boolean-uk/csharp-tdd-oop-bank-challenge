using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public interface IUser
    {
        /// <summary>
        /// Retrieve the name of the IUser object
        /// </summary>
        /// <returns> string - The name of the IUser</returns>
        string GetName();

        /// <summary>
        /// Retrieve the IAccount's associated with the IUser object
        /// </summary>
        /// <returns>List<IAccount> - A list of IAccount objects associated with the IAccount </returns>
        List<IAccount> GetAccounts();

        /// <summary>
        /// Register the IUser to belong to a provided IBankBranch
        /// </summary>
        /// <param name="branch"> IBankBranch - the branch the IUser should be associated with </param>
        /// <returns>bool - True if the IUser was successfully associated with the IBankBranch, false otherwise</returns>
        bool RegisterWithBankBranch(IBankBranch branch);
    }
}
