﻿using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class CurrentAccount : Account
    {

        public CurrentAccount(int id, BankTypes type, string owner)
        {
            this.ID = id;
            this.Type = type;
            this.Owner = owner;
        }

        public CurrentAccount(int id, BankTypes type, string owner, Branches branch)
        {
            this.ID = id;
            this.Type = type;
            this.Owner = owner;
            this.Branch = branch;
        }
    }
}
