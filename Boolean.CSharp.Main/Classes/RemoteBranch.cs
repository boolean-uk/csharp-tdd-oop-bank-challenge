using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class RemoteBranch : IBranch
    {
        public string Name => nameof(RemoteBranch);

        public List<IAccount> accounts => throw new NotImplementedException();

        public bool isInBranch(string name)
        {
            IAccount account = (IAccount)Bank.accounts.Where(x => x.AccountHolderName == name);
            if (accounts.Contains(account))
            {
                return true ;
            }
            return false;
        }

        public bool isIsBranch(string name)
        {
            throw new NotImplementedException();
        }
    }
}
