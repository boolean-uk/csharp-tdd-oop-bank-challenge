using Boolean.CSharp.Main.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface IOverdraft
    {
        double amount { get; set; }
        DateTime requestDateTime { get; set; }
        OverdraftStatus overdraftStatus { get; set; }

        void Approve();
        void Reject();
    }
}
