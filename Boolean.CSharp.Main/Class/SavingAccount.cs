using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main.Class
{
    public class SavingAccount : Account
    {
        public SavingAccount(Role owner) : base(owner)
        {
        }

    }
}
