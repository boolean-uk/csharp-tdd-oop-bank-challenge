﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Savings : Account
    {
        public Savings(Branch branch, string accountNr, string type, double balance) : base(branch, accountNr, type, balance)
        {
        }
    }
}
