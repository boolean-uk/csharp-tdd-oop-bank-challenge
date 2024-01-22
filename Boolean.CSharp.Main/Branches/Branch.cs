using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Branches
{
    public class Branch(string name, string description) : IBranch
    {
        public string Name => name;

        public string Description => description;

        public List<Request> Requests { get; set; } = [];
    }
}
