﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface IInitializable
    {
        // Replaces constructor...
        protected void Initialize(Bank bank, Account self);
    }
    
  
}
