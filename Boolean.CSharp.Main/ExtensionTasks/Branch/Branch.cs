using Boolean.CSharp.Main.ExtensionTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.ExtensionTasks.Branch
{
    internal class Branch : IBranch
    {
        public Branches _name {  get; set; }
        public string _location { get; set; }
    }
}
