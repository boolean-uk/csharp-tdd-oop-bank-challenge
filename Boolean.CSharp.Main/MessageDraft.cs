using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Boolean.CSharp.Main
{
    public class MessageDraft
    {
        private string body = "";
        public MessageDraft() { 
            
        }
       
        public string GetBody() { return body; }
        public void SetBody(string message) {  body = message; }

    }
}
