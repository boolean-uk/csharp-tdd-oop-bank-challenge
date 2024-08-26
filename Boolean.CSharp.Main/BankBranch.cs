using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class BankBranch
    {
        private string _name;
        private string _location;

        public BankBranch(string name, string location)
        {
            _name = name;
            _location = location;
        }

        public string Name { get { return _name; } }
        public string Location { get { return _location; } }
    }
}
