using Boolean.CSharp.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public interface IEmployee : IUser
    {
        /// <summary>
        /// Evaluate overdraft requests associated with the IEmployee object
        /// </summary>
        /// <param name="approval">bool - True if the overdraft is accepted, false otherwise</param>
        void EvaluateOverdraftRequests(bool approval);

        /// <summary>
        /// Generate a short summary of the oldest overdraft request, so the IEmployee can evaluate and approve/dismiss it within <see cref="EvaluateOverdraftRequests(bool)"/>
        /// </summary>
        /// <returns>string - the summary of the overdraft request submitter, amount, date, and account type</returns>
        string ShowOldestOverdraftRequest();

        /// <summary>
        /// Recieve an overdraft request for the IEmployee to handle.
        /// </summary>
        /// <param name="request"> IOverdraftRequest - the request to process </param>
        void AddOverdraftRequest(IOverdraftRequest request);
    }
}
