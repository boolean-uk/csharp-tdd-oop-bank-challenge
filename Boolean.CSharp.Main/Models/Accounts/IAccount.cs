using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Models.Transactions;

namespace Boolean.CSharp.Main.Models.Accounts
{
    public interface IAccount
    {

        string AccountNumber { get; set; }
        string AccountName { get; set; }
        Branch Branch { get; set; }
        List<BankStatement> BankStatements { get; set; }
        List<OverdraftRequest> OverdraftRequests { get; set; }
        List<ITransaction> Transactions { get; set; }
        public decimal GetBalance();
        public DebitTransaction Deposit(decimal amount);
        public CreditTransaction Withdraw(decimal amount);
        public OverdraftRequest RequestOverdraft(decimal amount);
        public decimal GetOverdraftLimit();

        public BankStatement CreateBankStatement();
    }
}
