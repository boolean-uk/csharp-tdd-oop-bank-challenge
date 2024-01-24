﻿using Boolean.CSharp.Main.CoreFiles;
using Boolean.CSharp.Main.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class AccountCurrent : Account
    {
        public AccountCurrent(Bank bank, User user, MobilePhone mobile = null) : base(bank, user, mobile)
        {

        }
    }
}
