using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class ConsoleMessenger : IMessenger
    {
        public void send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
