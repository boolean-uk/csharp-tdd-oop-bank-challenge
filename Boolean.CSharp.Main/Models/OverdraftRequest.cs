using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Models
{
    public class OverdraftRequest
    {
        public bool Approved { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public OverdraftRequest(decimal amount)
        {
            Amount = amount;
            Date = DateTime.Now;
        }
        public void Approve(Role role)
        {
            if(role == Role.Manager)
            {
                Approved = true;
            }
            else
            {
                throw new InvalidOperationException("Only managers can approve overdraft requests");
            }
        }

        public void Reject(Role role)
        {
            if (role == Role.Manager)
            {
                Approved = false;
            }
            else
            {
                throw new InvalidOperationException("Only managers can reject overdraft requests");
            }
        }
    }
}
