using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public enum TransactionType {
        DEPOSIT,
        WITHDRAW,
    }

    public class Transactions {
        public decimal Amount { get; }
        public TransactionType Type { get; }
        public decimal Balance { get; }
        public string DateOfTransaction { get; }
        public Account _Account { get; }


        public Transactions(decimal amount, TransactionType type, decimal balance, Account account) {
            Amount = amount;
            Type = type;
            Balance = balance;
            _Account = account;
            DateOfTransaction = DateTime.Now.ToString("hr-HR");
        }
    }
}