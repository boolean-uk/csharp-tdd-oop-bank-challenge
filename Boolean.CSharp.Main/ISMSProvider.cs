using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface ISMSProvider
    {
        public abstract bool SendSMS(string phonenr, string statement);
    }
}
