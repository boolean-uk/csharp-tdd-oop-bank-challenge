using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.ExtensionTasks.Interfaces
{
    public interface IOverdraft
    {
        Customer customer { get; set; }
        Guid guid { get; set; }
        double amount { get; set; }
    }
}
