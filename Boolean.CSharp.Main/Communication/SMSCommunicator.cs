using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Communication
{
    public class SMSCommunicator : ICommunicator
    {
        private readonly ISmsClient smsClient;

        public void Send(string message)
        {
            //Likely to recieve this from session data or something simmilar(?)
            string number = "123456789";
            smsClient.SendSmsAsync(number, message);
        }
    }
}
