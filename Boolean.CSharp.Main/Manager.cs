using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Manager : CustomerType
    {
        public Manager(int id)
        {
            setId(id);
            setAdmin(true);
        }

        private void AddUserToBranch(ICustomer user,Branch newbranch)
        {
           
        }

       
       
    }
       
}
