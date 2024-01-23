using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class User
    {
        private string _firstName;
        private string _lastName;
        private string _address;
        private Guid _id;

        public User(string firstName, string lastName, string address)
        {
            _firstName = firstName;
            _lastName = lastName;
            _address = address;
            _id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{_firstName} {_lastName}";
        }

        public string FirstName { get; }
        public string LastName { get; }

        public Guid Id { get { return _id; } set { _id = value; } }

        public string Address { get { return _address;} set { _address = value; } } 
    }
}
