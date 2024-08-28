using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class OverDraftRequest
    {
        public int ID { get; set; }
        public double Amount { get; set; }
        public RequestStatus Status { get; set; }
        public OverDraftRequest(int ID, double amount) 
        {
            this.ID = ID;
            this.Amount = amount;
            this.Status = RequestStatus.Pending;
        }
    }
}
