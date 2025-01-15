using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Branch
    {
        private string name;
        public Branch(string name) 
        {
            this.name = name;
        }
        public string Name() {  return name; }
    }
}
