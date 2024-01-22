using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        int deposit { get; set; }
        int withdraw { get; set; }
        int printStatement { get; set; }

        void GetBalance();
    }
}