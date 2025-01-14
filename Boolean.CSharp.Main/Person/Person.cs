using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Person
{
    public class Person
    {
        private int _id;
        private string _name;

        public Person(string name, int id) {

            _name = name;
            _id = id;
        
        }
        public string Name { get { return _name; } }

        public int Id { get { return _id; } }
    }
}
