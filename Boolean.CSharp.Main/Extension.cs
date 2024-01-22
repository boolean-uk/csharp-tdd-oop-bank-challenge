
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Manager : BankUser
    {
        private BankUser _bankuser;
        private SavingsAccount _savingsaccount;
        private string branch;
        public Manager()
        {
            _bankuser = new BankUser();
            _savingsaccount = new SavingsAccount();
            this.branch = string.Empty;
    }


        public string denieOverdraft(BankUser bankuser)
        {
            return "";
        }

        public string approveOverdraft(BankUser bankuser)
        {
            return "";
        }

        public void sendToPhone()
        { 
          
        }


    }
}


/*

request an overdraft - customer
        
approve or reject overdraft requests - manager

send bank statements as message to phone - customer  
  
 */
