using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Manager
    {

        public Manager() 
        { 
            
        }

        public string AcceptOverdraft(Account account, Overdraft overdraft)
        {
            return account.AcceptOverdraft(overdraft);
        }

        public string RejectOverdraft(Account account, Overdraft overdraft)
        {
            return account.RejectOverdraft(overdraft);
        }
        
    }
}
