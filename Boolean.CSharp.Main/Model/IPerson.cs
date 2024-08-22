using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal interface IPerson
    {
        string FirstName { get; }
        string LastName { get; }
        int Age { get; }
        string Email { get; }
        string PhoneNumber { get; }
        float CashOnHand { get; }

        
    }
}
