using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Collections.Generic;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {
        public decimal OverdraftLimit { get; private set; }
        public List<OverdraftRequest> OverdraftRequests { get; private set; }

        public CurrentAccount(decimal overdraftLimit, string branch) : base(branch)
        {
            OverdraftLimit = overdraftLimit;
            OverdraftRequests = new List<OverdraftRequest>();
        }

        public void RequestOverdraft(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Overdraft request amount must be greater than zero.");
            }

            if (amount > OverdraftLimit)
            {
                throw new InvalidOperationException("Overdraft request exceeds the overdraft limit.");
            }

            var overdraftRequest = new OverdraftRequest
            {
                Amount = amount,
                IsApproved = false,
                RequestDate = DateTime.Now
            };

            OverdraftRequests.Add(overdraftRequest);
        }

        public void ApproveOverdraftRequests()
        {
            foreach (var request in OverdraftRequests)
            {
                if (!request.IsApproved && request.Amount <= balance + OverdraftLimit)
                {
                    balance -= request.Amount;
                    transactions.Add(new Transaction
                    {
                        Date = DateTime.Now,
                        Amount = request.Amount,
                        Balance = balance,
                        IsDeposit = false
                    });
                    request.IsApproved = true;
                }
                else
                {
                    request.IsApproved = false;
                }
            }

            OverdraftRequests.RemoveAll(request => !request.IsApproved);

        }
    }
}