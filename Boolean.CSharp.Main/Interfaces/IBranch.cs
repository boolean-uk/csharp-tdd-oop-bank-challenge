using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    internal interface IBranch
    {

        string Name { get; }

        List<IAccount> accounts { get; }

        string getType(IAccount account);
    }
}
