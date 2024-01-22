using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank {
        


        private List<OverdraftRequest> _overdraftRequests = new List<OverdraftRequest>();

        // Extension
        public void RequestOverdraft(decimal amount) {
            OverdraftRequest request = new OverdraftRequest { Amount = amount, IsApproved = false };
            _overdraftRequests.Add(request);
        }

        // Extension
        public void ApproveOverdraft(int _id) {
            OverdraftRequest res = _overdraftRequests.FirstOrDefault(req => req.IsApproved == false);
            if (res != null) {
                res.IsApproved = true;
            }
        }
    }
}