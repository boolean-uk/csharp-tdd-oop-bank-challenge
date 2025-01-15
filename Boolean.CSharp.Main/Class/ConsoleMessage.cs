using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Abstract;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace Boolean.CSharp.Main.Class
{
    public class ConsoleMessage : MessageProvider
    {
        public ConsoleMessage(string message) : base(message)
        {
        }

        public override void SendMessage()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("         Bank Statement         ");
            sb.AppendLine("");
            sb.AppendLine($"{Message}");
            sb.AppendLine("");
            sb.AppendLine(" Regards,                       ");
            sb.AppendLine(" Your bank                      ");

            Console.WriteLine(sb.ToString());
        }
    }
}
