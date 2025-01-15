using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Communication
{
    public interface ICommunicator
    {
        void Send(string message);
    }
}
