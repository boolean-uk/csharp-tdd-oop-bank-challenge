using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class OverDraftRequest
    {
        private int _id;
        private decimal _amount;
        private Account _account;
        private OverDraftRequestStatus _status;

        public OverDraftRequest(int id,decimal amount, Account account)
        {
            _id = id;
            _amount = amount;
            _account = account;
            _status = OverDraftRequestStatus.Pending;
        }

        public int Id { get { return _id; } } 
        public decimal Amount { get { return _amount; } }
        public Account Account { get { return _account; } }
        public OverDraftRequestStatus Status { get {  return _status; }  set { _status = value; } }
    }
}
