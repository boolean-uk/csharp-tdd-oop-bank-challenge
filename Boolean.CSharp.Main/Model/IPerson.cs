using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal interface IPerson
    {
        internal string FirstName { get; }
        internal string LastName { get; }
        internal int Age { get; }
        internal string Email { get; }
        internal string PhoneNumber { get; }
        internal float CashOnHand { get; }

        
    }
}
