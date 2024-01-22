using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public class RegularCustomer : Customer, IUser
    {
        public RegularCustomer(string name) : base(name)
        {
        }
    }
}
