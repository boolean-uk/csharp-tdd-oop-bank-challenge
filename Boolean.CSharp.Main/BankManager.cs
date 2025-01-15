using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Enums;
namespace Boolean.CSharp.Main
{
    public class BankManager : IPerson
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public BankManager(string id, string name) 
        {
            Name = name;
            Id = id;
        }

        public void HandleOverdraftRequest(OverdraftRequest request, bool isApproved)
        {
            if (isApproved)
            {
                request.Account.OverdraftLimit = request.RequestedAmount;
                request.RequestStatus = RequestStatus.Approved;
            }
            else
            {
                request.RequestStatus = RequestStatus.Rejected;
            }
        }
    }
}