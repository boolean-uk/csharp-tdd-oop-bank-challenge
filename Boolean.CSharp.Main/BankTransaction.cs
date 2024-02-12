using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Boolean.CSharp.Main
{
    public class BankTransaction
    {
      
        public string Date { get; set; }
        public Enums.Transaction TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal OldBalance { get; set; }
        public decimal NewBalance { get; set; }

        public decimal makeTransaction(string date,string transactionType, decimal amount, IAccount account)
        {
            Date = date;
            Amount = amount;

            if (transactionType == "Withdrawal" || transactionType == "Deposit")
            {
                TransactionType = transactionType == "Withdrawal" ? Enums.Transaction.Withdraw : Enums.Transaction.Deposit;

                if (account is CurrentAccount currentAccount)
                {
                    NewBalance = (transactionType == "Withdrawal" ? currentAccount.Balance - amount : currentAccount.Balance + amount);
                    currentAccount.Balance = NewBalance;
                }
                else if (account is SavingsAccount savingsAccount)
                {
                    NewBalance = transactionType == "Withdrawal" ? savingsAccount.Balance - amount : savingsAccount.Balance + amount;
                    savingsAccount.Balance = NewBalance;
                }
            }

            return NewBalance;

        }
    }
}
