using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface Iperson
    {
        public void CreateCurrentAccount();
        public void CreateSavingsAccount();
        public string ActivateSmsStatements();
        public Request RequestOverdraft();
        public Iaccount GetCurrentAccount();
        public Iaccount GetSavingsAccount();    

    }
}
