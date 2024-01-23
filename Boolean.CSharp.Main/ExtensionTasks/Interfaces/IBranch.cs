using Boolean.CSharp.Main.ExtensionTasks.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.ExtensionTasks.Interfaces
{
    public interface IBranch
    {
        Branches _name { get; set; }
        string _location { get; set; }
    }
}
