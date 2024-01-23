using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        public string _firstName { get; set; }
        public string _lastName { get; set; }
        public DateTime _dateOfBirth { get; set; }
        public Customer(string firstname, string lastname, DateTime dateOfBirth) 
        {
            this._firstName = firstname;
            this._lastName = lastname;
            this._dateOfBirth = dateOfBirth;
        }
    }
}
