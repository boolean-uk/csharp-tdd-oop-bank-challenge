using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Models
{
    public class OverdraftRequest
    {
        public int AccountID { get; set; }
        public double Amount { get; set; }

        public OverdraftRequest(int accountID, double amount)
        {
            AccountID = accountID;
            Amount = amount;
        }
    }

    public class OverdraftManager
    {
        public Dictionary<int, OverdraftRequest> Requests { get; set; }

        public OverdraftManager()
        {
            Requests = new Dictionary<int, OverdraftRequest>();
        }

        public void CreateRequest(int accountID, double amount)
        {
            throw new NotImplementedException();
        }

        public void ApproveRequest(int accountID, double amount)
        {
            throw new NotImplementedException();
        }
        public void RejectRequest(int accountID)
        {
            throw new NotImplementedException();
        }
    }
}
