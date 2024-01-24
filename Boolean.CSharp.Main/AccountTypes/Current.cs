using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.AccountTypes
{
    public class Current:Account,IAccount
    {
        public Current() 
        {
            SetType("current");
        }
    }
}
