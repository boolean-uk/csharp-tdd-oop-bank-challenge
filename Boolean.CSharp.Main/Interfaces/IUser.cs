using Boolean.CSharp.Main.AccountTypes;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<IAccount> AccountsList { get; set; }
        public List<OverdraftRequest> OverdraftRequests { get; set; }

    }
}