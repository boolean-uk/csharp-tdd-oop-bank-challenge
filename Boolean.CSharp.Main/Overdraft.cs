using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Overdraft : IOverdraft
    {
        public double odBalance => throw new NotImplementedException();

        public double maxOd => throw new NotImplementedException();
    }
}
