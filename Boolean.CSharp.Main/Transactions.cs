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
        public string DateOfTransaction { get; }
        public Account _Account { get; }


        public Transactions(decimal amount, TransactionType type, Account account) {
            Amount = amount;
            Type = type;
            _Account = account;
            DateOfTransaction = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}