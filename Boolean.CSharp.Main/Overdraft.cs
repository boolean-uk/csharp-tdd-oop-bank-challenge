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
        public Overdraft(BankAccount requesting) 
        {  
            Requesting = requesting; 
        }

        public bool Approve()
        {
            return true;

        }

        public bool Reject()
        {
            return false;

        }
    }
}
