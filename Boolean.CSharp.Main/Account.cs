﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        private string _accountnr;
        private string _type;
        private string _branch;
        //private string _ownername;
        private double _balance;

        public Account(string accountNr, string type, string branch, double balance)
        {
            _accountnr = accountNr;
            _type = type;
            _branch = branch;
            //_ownername = ownerName;
            _balance = balance;
        }

        string AccountNr { get => _accountnr; set => _accountnr = value; }
        string Type { get => _type; set => _type = value; }
        string Branch { get => _branch; set => _branch = value; }
        //string OwnerName { get => _ownername; set => _ownername = value; }
        double Balance { get => _balance; set => _balance = value; }
        public string GetOwnerName()
        {
            return "";
        }

    }
}
