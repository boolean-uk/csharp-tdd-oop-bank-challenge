using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Models.Transactions;

namespace Boolean.CSharp.Main.Models.Accounts
{
    public class SavingsAccount : IAccount
    {
        public string AccountNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string AccountName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Branch Branch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<OverdraftRequest> OverdraftRequests { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<ITransaction> Transactions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<BankStatement> BankStatements { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Transaction Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public decimal GetBalance()
        {
            throw new NotImplementedException();
        }

        public decimal GetOverdraftLimit()
        {
            throw new NotImplementedException();
        }

        public void RequestOverdraft(decimal amount)
        {
            throw new NotImplementedException();
        }

        public Transaction Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
