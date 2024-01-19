using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Boolean.CSharp.Main
{
    public class OverdraftRequest
    {
        public decimal Amount { get; set; }
        public bool IsApproved { get; set; }
        public DateTime RequestDate { get; set; }

        public OverdraftRequest(decimal amount = 0)
        {
            Amount = amount;
            IsApproved = false;
            RequestDate = DateTime.Now;
        }
    }
}
