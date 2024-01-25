using Boolean.CSharp.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class SavingsAccount : BankAccount
    {
        // Additional property to track overdraft status
        public bool? IsOverdraftPending { get; set; }

        public bool RequestOverdraft()
        {
            // Check if overdraft has already been requested
            if (IsOverdraftRequested)
            {
                return false;
            }

            // Create an overdraft instance and request it
            Overdraft overdraft = new Overdraft(this);
            if (overdraft.RequestOverdraft())
            {
                // Set the overdraft requested 
                IsOverdraftRequested = true;

                IsOverdraftPending = true;

                return true;
            }

            return false;
        }

    }
}


