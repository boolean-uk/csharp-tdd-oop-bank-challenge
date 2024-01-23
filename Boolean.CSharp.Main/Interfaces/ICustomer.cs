using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface ICustomer
    {
        public CreditScore CreditScore { get; set; }
        void AddAccount(IAccount account);
        List<IAccount> GetAccounts();
    }
}
