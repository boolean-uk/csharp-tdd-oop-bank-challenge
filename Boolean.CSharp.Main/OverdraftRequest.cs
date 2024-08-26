using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class OverdraftRequest
    {
        private string _status;

        public OverdraftRequest(IAccount account, decimal amount, string status) { 
      
            Account = account;
            RequestedAmount = amount;
            Status = status;
        }

        public void Approve()
        {
            _status = "Approved";
        }

        public void Reject()
        {
            _status = "Rejected";
        }
        public IAccount Account { get; set; }
        public decimal RequestedAmount { get; set; }
        public string Status { get { return _status; } set { _status = value; } }

    }
}
