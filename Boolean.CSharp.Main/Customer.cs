using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class Customer : User
    {

        public Customer(int id, string name, string address, string phoneNumber) : base(id, name, address, phoneNumber)
        {
            
        }

    }
}
