using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class Bank
    {

        private List<IAccount> _accounts;
        public string bankName { get; set; }

        public List<IAccount> accounts
        {
            get { return _accounts; }
            set { _accounts = value; }
        }

        public bool handleRequst(Request request, bool decision) {
        
            if (request == null) return false;
            else
            {
                decimal sumToGive = request.amount;
                request.account.updateOverdraft(request.account,decision,sumToGive);
                return true;
            }
        }
    }
}
