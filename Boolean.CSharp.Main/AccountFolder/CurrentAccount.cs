using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boolean.CSharp.Main.AccountFolder.Enums;

namespace Boolean.CSharp.Main.AccountFolder
{
    public class CurrentAccount : Account
    {
        private Branches _branch;

        public CurrentAccount(Branches branch)
        {
            _branch = branch;
        }

        public Branches branch { get { return _branch; } }
    }
}
