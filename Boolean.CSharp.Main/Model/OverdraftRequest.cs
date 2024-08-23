using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class OverdraftRequest
    {
        private int _customerID;
        private float _amount;
        private string _reason;
        private bool _isApproved;
        public OverdraftRequest(int customerID, float _amount, string _reason)
        {
            this._customerID = customerID;
            this._amount = _amount;
            this._reason = _reason;
            this._isApproved = false;
        }
        
        internal int getCustomerID() { return _customerID; }
        internal float getAmount() { return _amount; }
        internal string getReason() { return _reason; }
        internal bool getIsApproved() { return _isApproved; }
        internal void approve() { _isApproved = true; }
    }
}
