using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Person : Iperson
    {
        public Iaccount? CurrentAccount { get; set; } 
        public Iaccount? SavingsAccount { get; set; }   

        public string ActivateSmsStatements()
        {
            throw new NotImplementedException();
        }

        public void CreateCurrentAccount()
        {
            CurrentAccount= new Account();  
        }
        public Iaccount? GetCurrentAccount()
        {
            return CurrentAccount;
        }
        public void CreateSavingsAccount()
        {
            SavingsAccount= new Account();
        }
        public Iaccount? GetSavingsAccount()
        {
            return SavingsAccount;
        }
        public string GenerateBankStatements()
        {
            throw new NotImplementedException();
        }



        public Request RequestOverdraft()
        {
            throw new NotImplementedException();
        }
    }
}
