using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface ICustomer
    {
        string Fullname { get; }
        string Address { get; }
        string City { get; }
        int Customerid { get; }
        int Dateofbirth { get; }
    }
}
