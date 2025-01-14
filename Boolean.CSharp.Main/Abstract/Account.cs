using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main.Abstract
{
    public abstract class Account
    {
        public Guid AccountNumber { get; set; } = Guid.NewGuid();
        public Branch Branch { get; set; }
    }
}
