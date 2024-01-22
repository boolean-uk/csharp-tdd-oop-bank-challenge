using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class OverdraftRequest
    {
        public double Amount {  get; set; }
        public DateTime RequestTime { get; set; }
        public eStatus RequestStatus { get; set; }
    }
}
