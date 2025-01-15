using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class RuralBranch : IBranch
    {
        public string Name => nameof(RuralBranch);

        public List<IAccount> accounts { get; set; }

        public bool isIsBranch(string name)
        {
            IAccount account = (IAccount)Bank.accounts.Where(x => x.AccountHolderName == name);
            if (accounts.Contains(account))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
