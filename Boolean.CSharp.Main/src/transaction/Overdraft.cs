using Boolean.CSharp.Main.extra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.src.transaction
{
    public class Overdraft
    {
        private DateTime _time;
        private Status _status;
        private double _amount;

        public Status Status { get { return _status; } }
        public double Amount { get { return _amount; } }

        public Overdraft(double amount)
        {
            _status = Status.Pending;
            _amount = amount;
            _time = DateTime.Now;
        }

        public void Approve()
        {
            _status = Status.Approved; 
        }

        public void Reject()
        {
            _status = Status.Declined;
        }

    }
}
