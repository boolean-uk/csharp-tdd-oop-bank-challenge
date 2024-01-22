using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class OverdraftRequest
    {
        public int _id;
        public DateTime _requestTime;
        public OverdraftStatus _status;
        public double _amount;

        public OverdraftRequest(int Id, double amount)
        {
            _id = Id;
            _requestTime = DateTime.Now;
            _amount = amount;
            if (amount <= 0) { _status = OverdraftStatus.Approved; }
            else { _status = OverdraftStatus.Pending; }
        }

        public int Id { get => _id; }
        public DateTime RequestTime { get => _requestTime; }
        public OverdraftStatus Status { get => _status; set => _status = value; }
        public double Amount { get => _amount; }
    }
}
