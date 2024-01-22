﻿using Boolean.CSharp.Main.Accounts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public interface IAccount
    {
        int _AccId { get; set; }
        bool _IsAccActive { get; set; }
        Branches _Branch { get; }

    }
}
