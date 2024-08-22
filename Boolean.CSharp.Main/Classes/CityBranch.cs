using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class CityBranch : IBranch
    {
        public string Name => throw new NotImplementedException();

        public List<IAccount> accounts => throw new NotImplementedException();

        public string getType(IAccount account)
        {
            throw new NotImplementedException();
        }
    }
}
