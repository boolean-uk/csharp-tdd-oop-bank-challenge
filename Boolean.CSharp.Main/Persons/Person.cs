using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Persons
{
    public abstract class Person
    {
        #region Properties
        private Bank _bank;
        private int _id;
        private string _name;

        public Bank Bank { get => _bank; }
        public int ID { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        #endregion

        public Person (Bank bank, int id, string name)
        {
            _bank = bank;
            _id = id;
            _name = name;
        }
    }
}
