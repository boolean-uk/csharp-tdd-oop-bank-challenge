using Boolean.CSharp.Main.ExtensionTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.ExtensionTasks
{
    public class Overdraft : IOverdraft
    {
        public Customer customer { get; set; }
        public Guid guid { get; set; }
        public double amount { get; set; }
    }
}
