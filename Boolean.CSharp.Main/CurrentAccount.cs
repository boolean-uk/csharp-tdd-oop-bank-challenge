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
        //public decimal OverdraftLimit { get; private set; }
        //public List<OverdraftRequest> OverdraftRequests { get; private set; }

        //public CurrentAccount(decimal overdraftLimit)
        //{
        //    OverdraftLimit = overdraftLimit;
        //    OverdraftRequests = new List<OverdraftRequest>();
        //}

        //public void RequestOverdraft(decimal amount)
        //{
        //    if (amount <= 0)
        //    {
        //        throw new ArgumentException("Overdraft request amount must be greater than zero.");
        //    }

        //    if (amount > OverdraftLimit)
        //    {
        //        throw new InvalidOperationException("Overdraft request exceeds the overdraft limit.");
        //    }

        //    if ((balance - amount) < -OverdraftLimit)
        //    {
        //        throw new InvalidOperationException("Overdraft request would result in a negative balance beyond the overdraft limit.");
        //    }

        //    var overdraftTransaction = new Transaction
        //    {
        //        Date = DateTime.Now,
        //        Amount = amount,
        //        Balance = balance - amount, 
        //        IsDeposit = false 
        //    };

        //    transactions.Add(overdraftTransaction);
        //    balance -= amount; 
        //}

        public decimal OverdraftLimit { get; private set; }
        public List<OverdraftRequest> OverdraftRequests { get; private set; }

        public CurrentAccount(decimal overdraftLimit)
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

            // var overdraftRequest = new OverdraftRequest(amount); // Provide the 'amount' parameter

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