using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface IAccount
    {
        List<Transaction> Transactions {get; set;}
        List<Transaction> Overdraft { get; set; }
        string User { get; set; }
        string Branch { get; set; }

        string Name { get; set; }
        void Deposit(decimal money);
        bool Withdraw(decimal money);
        void OverdraftRequest(decimal money);
        bool OverdraftApproval(bool admin, bool accept, Guid id);
        decimal Total();
        string BankStatement();
    }
}
