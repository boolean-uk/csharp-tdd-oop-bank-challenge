using Boolean.CSharp.Main.ExtensionTasks.Interfaces;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Extension
{
    public class CurrentAccountEX : AccountEX
    {        
        public CurrentAccountEX(IBranch branch) : base(new List<ITransaction>(), branch)
        {            
        }
    }
}
