using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transations
{
    public class TransactionStatus
    {
        private bool status = false;

        public bool Status { get { return status; } set { status = value; } }

    }
}
