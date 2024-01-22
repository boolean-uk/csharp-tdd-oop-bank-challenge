using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface IUser
    {
        string Name { get; set; }
        string PhoneNumber { get; set; }
        bool HasCurrentAccount { get; set; }
        bool HasSavingsAccount { get; set; }
    }
}
