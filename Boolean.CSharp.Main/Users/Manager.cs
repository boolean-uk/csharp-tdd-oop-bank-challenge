using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branch;
using Boolean.CSharp.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public class Manager : IEmployee
    {
        private string _name;
        private List<IAccount> _accounts = new List<IAccount>();
        private IBankBranch? _branch;
        private List<IOverdraftRequest> _overdraftRequests = new List<IOverdraftRequest>();

        public Manager(string name)
        {
            _name = name;
        }

        /// <inheritdoc />
        /// <remarks> For Manager objects the request is placed within a List until the Manager object clear the object at a later time, see <see cref="EvaluateOverdraftRequests"> and <see cref="ShowOldestOverdraftRequest"/></remarks>
        public void AddOverdraftRequest(IOverdraftRequest request)
        {
            _overdraftRequests.Add(request);
        }

        /// <inheritdoc />
        public void EvaluateOverdraftRequests(bool approval)
        {
            IOverdraftRequest? request = _overdraftRequests.OrderByDescending(req => req.GetRequestDate()).LastOrDefault();
            if (request == null)
            {
                return;
            }

            if (approval) 
            {
                decimal desiredValue = request.GetRequestOverdraftLimit();
                IAccount account = request.GetOverdraftRequestAccount();
                account.SetOverdrawLimit(desiredValue, this);
            }
        }

        /// <inheritdoc />
        public List<IAccount> GetAccounts()
        {
            return new List<IAccount>(_accounts);
        }

        /// <inheritdoc />
        public string GetName()
        {
            return _name;
        }

        /// <inheritdoc />
        public bool RegisterWithBankBranch(IBankBranch branch)
        {
            _branch = branch;
            return branch.AddEmployeeToBranch(this);
        }

        /// <inheritdoc />
        public string ShowOldestOverdraftRequest()
        {
            IOverdraftRequest? request = _overdraftRequests.OrderByDescending(req => req.GetRequestDate()).LastOrDefault();
            if (request == null)
            {
                return "";
            }
            else 
            {
                StringBuilder sb = new StringBuilder();
                
                sb.Append($"Requester: { request.GetRequester().GetName()}, ");
                sb.Append($"amount: {request.GetRequestOverdraftLimit()}, ");
                sb.Append($"account type: {request.GetOverdraftRequestAccount().GetType().Name}, ");
                sb.Append($"submitted: {request.GetRequestDate().ToString("yyyy-MM-dd HH:mm:ss")}");

                return sb.ToString();
            }
        }
    }
}
