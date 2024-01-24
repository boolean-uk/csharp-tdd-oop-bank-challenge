using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface IAccount
    {
        public bool OverdraftApproved { get; set; }
        Branch Branch { get;set; }
        void AddTransaction(ITransaction transaction);
        double GetBalance();

        string GenerateBankStatement();

        void SendBankstatementSMS();
    }
}
