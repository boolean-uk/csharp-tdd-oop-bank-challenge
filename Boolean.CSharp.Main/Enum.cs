using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public enum Location
    {
        Vanderbijlpark = 10012,
        Oslo = 32142,
        Kristiansand = 89654,
        Manchester = 21547,
        London = 89996,
        Johannesburg = 77854
       
    }
    public enum Status { pending, approved, rejected };
    public enum Type { credit, debit };
}
