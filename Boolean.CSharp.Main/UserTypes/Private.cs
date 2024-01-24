using Boolean.CSharp.Main.AccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Private:CustomerType, ICustomer
    {
       public Private(int id) {
            setId(id);
                    
        }
       
    }
}
