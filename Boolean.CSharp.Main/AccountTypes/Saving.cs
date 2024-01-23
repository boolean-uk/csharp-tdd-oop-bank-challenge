using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.AccountTypes
{
    public class Saving : Account,IAccount
    {
        public Saving()
        {
            SetType("saving");
        }

    }
}
