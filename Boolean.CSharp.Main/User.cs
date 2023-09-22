using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public abstract class User
    {
        private static int id = 0;

        private int _id;
        private string _name;
        private string _address;
        private string _phoneNumber;

        public User(string name, string address, string phoneNumber)
        {
            _id = ++id;
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
        }

        public int Id { get => _id; }
    }
}
