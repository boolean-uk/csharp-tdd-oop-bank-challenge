using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class OverdraftRequest
    {
        private decimal amount;
        private DateTime date;
        private Status status;
        public OverdraftRequest(decimal amount, DateTime date)
        {
            this.amount = amount;
            this.date = date;
            this.status = Status.Pending;
        }

        public decimal Amount { get => this.amount; }
        public DateTime Date { get => this.date; }
        public Status Status { get => this.status; set => this.status = value; }
    }
}
