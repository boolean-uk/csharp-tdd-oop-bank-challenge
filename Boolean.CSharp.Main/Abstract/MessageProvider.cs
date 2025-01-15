using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main.Abstract
{
    public abstract class MessageProvider : IMessage
    {
        private string _message;

        public MessageProvider(string message) 
        {
            _message = message;
        }

        public abstract void SendMessage();

        public string Message { get => _message; set => _message = value; }
    }
}
