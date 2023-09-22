using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public abstract class User
    {
        private int _id;
        private string _name;
        private string _address;
        private string _phoneNumber;

        public User(int id, string name, string address, string phoneNumber)
        {
            _id = id;
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
        }

    }
}
