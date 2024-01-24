using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface ICustomer
    {
        public int Id { get; }
        public int Branch { get; set; }
    }

}

