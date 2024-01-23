using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank {
        


        private List<OverdraftRequest> _overdraftRequests = new List<OverdraftRequest>();

        // Extension
        public void RequestOverdraft(IAccount account, decimal amount) {
            if ((Account)account != null && amount > 0) {
                OverdraftRequest request = new OverdraftRequest { Amount = amount, IsApproved = false };
                _overdraftRequests.Add(request);
            } else {
                throw new Exception("You must enter the account you want to file the overdraft amount of!");
            }

            
        }

        // Extension
        public void ApproveOverdraft(int _id) {
           /* OverdraftRequest res = _overdraftRequests.FirstOrDefault(req => req.);
            if (res != null) {
                res.IsApproved = true;
            }*/
        }
    }
}