using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface IAccount
    {
        string Owner {  get; set; }
        int Balance { get; set; }
    }
}
