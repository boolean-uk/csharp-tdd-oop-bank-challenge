using Boolean.CSharp.Main.Overdraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.User
{
    public class Manager
    {
        public Manager() { }

        public void EditRequest(OverdraftObj request, OverdraftStatus status)
        {
            request.OverdraftStatus = status;
        }
    }
}
