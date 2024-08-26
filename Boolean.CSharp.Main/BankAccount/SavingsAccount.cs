using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.BankAccount
{
    public class SavingsAccount : IBankAccount
    {
        public string AccountName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool savingsAccount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Transaction> transactionHistory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
