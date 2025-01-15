using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Class;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interface;
using Transaction = Boolean.CSharp.Main.Class.Transaction;

namespace Boolean.CSharp.Main.Abstract
{
    public abstract class Request
    {
        private Account _account;
       public Request(ref Account account) 
        {
            _account = account;
        }

        public Account Account { get => _account; set => _account = value; }
    }
}
