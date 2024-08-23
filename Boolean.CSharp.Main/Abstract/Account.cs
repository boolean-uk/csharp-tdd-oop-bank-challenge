using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Abstract
{
    public abstract class Account
    {
        public ICustomer owner;
        public IBranch branch;
        public bool current;

        protected Account(ICustomer owner, IBranch branch, bool current)
        {
            this.owner = owner;
            this.branch = branch;
            this.current = current;
        }
    }
}
