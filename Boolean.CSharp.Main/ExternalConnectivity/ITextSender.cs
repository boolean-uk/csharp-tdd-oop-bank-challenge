using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.MessageProvider
{
    public interface ITextSender
    {
        /// <summary>
        /// Send a message through external sources to the customer.
        /// </summary>
        /// <param name="message"> string - The message to send out </param>
        void SendMessage(string message);
    }
}
