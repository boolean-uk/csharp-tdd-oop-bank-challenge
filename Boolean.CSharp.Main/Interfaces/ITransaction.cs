using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface ITransaction
    {
        public void SetBalance(double balance);
        Tuple<DateTime, double, double> GetDetails();
    }
}
