using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{

    public class OverdraftRequest
    {

        private double _amountRequested;
        private RequestStatus _status;
       
        public OverdraftRequest(double amount)
        {
            if (amount < 0)
            {
                amount = 0;
                Console.WriteLine("overdraftRequest amount was less than 0. changed value to 0.");
            }
            _amountRequested = amount;
            _status = RequestStatus.Waiting_for_answer;
        }

        public double amountRequested { get { return _amountRequested; } }
        public RequestStatus status { get { return _status; } }
        public enum RequestStatus
        {
            Approved,
            Waiting_for_answer,
            Denied
        }
        public void SetStatus(RequestStatus status)
        {
            _status = status;
        }
    }
}
