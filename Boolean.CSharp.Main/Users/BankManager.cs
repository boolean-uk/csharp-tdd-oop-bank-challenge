using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public class BankManager
    {
        private readonly Customer customer;
        public void ApproveOverdraft()
        {
            customer.status = Enums.OverdraftStatus.Approved;
        }
        
        public void RejectOverdraft()
        {
            customer.status = Enums.OverdraftStatus.Rejected;
        }

        public void ChangeAccountBranch(Account account, Enums.Branches newBranch)
        {
            account.Branch = newBranch;
        }

        public Enums.Branches GetBranch(Account account) 
        {
            return account.Branch; 
        }



    }
}
