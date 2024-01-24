using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Business:CustomerType,ICustomer
    {
        public Business(int id) {
            setId(id);
        }

        
    }
}
