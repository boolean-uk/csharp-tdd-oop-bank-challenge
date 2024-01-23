using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Objects
{
    public class Branch
    {
        private int _id;
        private string _name;
        private string _location;

        public Branch(string name, string location)
        {
            _id += 1;
            _name = name;
            _location = location;
        }

        public int Id {  get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Location { get { return _location; } set { _location = value; } }
    }
}
