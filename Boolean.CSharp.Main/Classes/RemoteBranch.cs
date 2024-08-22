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

        public string getName(IAccount account)
        {
            if (accounts.Contains(account))
            {
                return Name;
            }
            return "Account not in this branch";
        }
    }
}
