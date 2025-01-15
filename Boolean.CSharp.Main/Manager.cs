using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Manager : Person, Imanager
    {
        public string ActivateSmsStatements()
        {
            throw new NotImplementedException();
        }

        public void ApproveOverdraft(Request request)
        {
            throw new NotImplementedException();
        }

        public void CreateCurrentAccount()
        {
            throw new NotImplementedException();
        }

        public void CreateSavingsAccount()
        {
            throw new NotImplementedException();
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
