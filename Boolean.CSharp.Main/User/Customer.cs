using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.User
{
    public class Customer : ICustomer
    {
        private string _fullname;
        private string _address;
        private string _city;
        private int _customerid;
        private int _dateofbirth;

        public Customer(string fullname, string address, string city, int customerid, int dateofbirth)
        {
            _fullname = fullname;
            _address = address;
            _city = city;
            _customerid = customerid;
            _dateofbirth = dateofbirth;
        }

        public string Fullname { get { return _fullname; } set { _fullname = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string City { get { return _city; } set { _city = value; } }
        public int Customerid { get { return _customerid; } set { _customerid = value; } }
        public int Dateofbirth {  get { return _dateofbirth; } set { _dateofbirth = value; } }
    }
}
