using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Types;

namespace Boolean.CSharp.Main.Other
{
    public class MobilePhone
    {

        public MobilePhone(string phoneNumber = "+4712345789") {
            PhoneNumber = phoneNumber;
        }
        public string PhoneNumber { get; set; }
        public List<string> SMSs { get; } = new List<string>();

    }
}
