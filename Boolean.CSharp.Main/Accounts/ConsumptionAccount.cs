﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main.Accounts
{
    public class ConsumptionAccount : Account
    {
        public ConsumptionAccount(User owner, Branch branch) : base(owner, branch) {}
    }
}