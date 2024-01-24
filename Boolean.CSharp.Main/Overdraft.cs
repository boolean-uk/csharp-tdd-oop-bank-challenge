using Boolean.CSharp.Main.Enum;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Overdraft : IOverdraft
    {
        public double amount { get; set; }
        public DateTime requestDateTime { get; set; }   
        public OverdraftStatus overdraftStatus { get; set; }

        
        public Overdraft(double amount) {
            this.amount = amount;
            requestDateTime = DateTime.Now;
            overdraftStatus = OverdraftStatus.Pending;
        }

        public void Approve()
        {
            overdraftStatus = OverdraftStatus.Approved;
        }
        public void Reject()
        {
            overdraftStatus = OverdraftStatus.Rejected;
        }
    }
}
