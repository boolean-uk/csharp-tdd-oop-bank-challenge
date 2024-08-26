using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Persons
{
    public abstract class Person
    {
        private Bank _bank;
        private int _id;
        private string _name;

        public Bank Bank { get => _bank; }
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

        public Person (Bank bank, int id, string name)
        {
            _bank = bank;
            _id = id;
            _name = name;
        }
    }
}
