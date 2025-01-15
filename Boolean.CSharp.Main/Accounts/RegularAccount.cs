using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Exceptions;

namespace Boolean.CSharp.Main.Accounts
{
    public class RegularAccount : Account
    {
        public RegularAccount(string name, Branch branch = Branch.Trondheim, string bankSecret = "") : base(name, branch, bankSecret) { }

        public override AccountTransaction Deposit(double amount)
        {
            if (amount < 0) throw new IllegalOperationException($"It is not possible to deposit a negative amount! Your attempted deposit: {amount}");
            AccountTransaction transaction = new(AccountId, amount);
            AddTransaction(transaction);
            return transaction;
        }

        public override AccountTransaction Withdraw(double amount)
        {
            if (amount > Balance) throw new InsufficientFundsException($"You do not have enough money to withdraw: {amount}");
            AccountTransaction transaction = new(AccountId, -amount);
            AddTransaction(transaction);
            return transaction;
        }
    }
}
