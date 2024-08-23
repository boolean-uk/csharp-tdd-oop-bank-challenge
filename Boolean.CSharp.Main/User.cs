﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public class User
    {
        private string _name;
        private Role _role;

        public User(string name, Role role)
        {
            _name = name;
            _role = role;
        }

        public string Name { get { return _name; } }
        public Role Role { get { return _role; } }
    }
}