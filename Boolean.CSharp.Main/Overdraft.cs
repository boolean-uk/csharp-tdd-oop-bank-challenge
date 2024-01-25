using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Overdraft
    {
        public BankAccount Requesting { get; }
        public bool IsOverdraftRequested { get; private set; }
        public Overdraft(BankAccount requesting) 
        {  
            Requesting = requesting; 
        }

        public bool RequestOverdraft()
        {
            if (!IsOverdraftRequested)
            {
                IsOverdraftRequested = true;
                return true;
            }

            return false;
        }

        public bool Approve()
        {
            if (!IsOverdraftRequested)
            {
                IsOverdraftRequested = true;

                // Set a property in the associated BankAccount
                Requesting.IsOverdraftApproved = true;

                return true;
            }

            return false;
        }

        public bool Reject()
        {
            if (IsOverdraftRequested)
            {
                IsOverdraftRequested = false;

                // Set a property in the associated BankAccount 
                Requesting.IsOverdraftApproved = false;

                return true;
            }

            return false;
        }
    }
}
