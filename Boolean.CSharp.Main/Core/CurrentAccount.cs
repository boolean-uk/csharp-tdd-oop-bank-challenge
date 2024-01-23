﻿using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Core
{
    public class CurrentAccount : AAccount
    {
        public CurrentAccount() : base() { }

        public CurrentAccount(Branch branch) : base(branch) { }
    }
}
