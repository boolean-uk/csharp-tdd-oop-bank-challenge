using Boolean.CSharp.Main.AccountFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boolean.CSharp.Main.AccountFolder.Enums;

namespace Boolean.CSharp.Main
{
    public class OverdraftRequest
    {
        private int _id;
        private decimal _amount;
        private Account _account;
        private OverdraftRequests _status;

        public OverdraftRequest(int id, decimal amount, Account account)
        {
            _id = id;
            _amount = amount;
            _account = account;
            _status = OverdraftRequests.Pending;
        }

        public int Id { get { return _id; } }
        public decimal Amount { get { return _amount; } }
        public Account Account { get { return _account; } }
        public OverdraftRequests Status { get { return _status; } set { _status = value; } }


    }
}
