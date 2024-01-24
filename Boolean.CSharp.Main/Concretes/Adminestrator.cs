using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Concretes
{
    public class Adminestrator : IAdminestrator
    {
        private List<IAccount> _requested = new List<IAccount>();
        private List<IAccount> _approved = new List<IAccount>();

        public Adminestrator() { }

        public void RequestOverdraft(IAccount account)
        {
            if (_requested.Contains(account)) { Console.WriteLine("Customer has already requested overdraft"); }
            else { _requested.Add(account); }
        }

        private bool verifyUser(ICustomer user)
        {
            bool verified = false;
            if (user.CreditScore >= CreditScore.Nutral) { verified=true; }
            return verified;
        }

        public void ApproveOverdraft(ICustomer user, IAccount account)
        {
            if (!_requested.Contains(account)) { Console.WriteLine("The customer has not requested overdraft"); }
            else if (verifyUser(user)) 
            { 
                _approved.Add(account); 
                account.OverdraftApproved = true;
            }
        }

        public void DisableOverdraft(IAccount account)
        {
            if (!_approved.Contains(account)) { Console.WriteLine("No such account to disable"); }
            else { _approved.Remove(account); }
        }

        
    }
}
