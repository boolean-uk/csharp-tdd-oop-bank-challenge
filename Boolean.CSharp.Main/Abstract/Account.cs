using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main.Abstract
{
    public abstract class Account
    {
        public Account(Guid ownerID, string accountName)
        {
            OwnerID = ownerID;
            AccountName = accountName;
        }

        public float CalculateFunds()
        {
            float funds = 0f;

            foreach(Transaction transaction in BankData.Transactions)
            {
                if (AccountNumber == transaction.FromAccountNumber)
                {
                    funds -= transaction.Amount;
                    Console.WriteLine(transaction.Amount);
                }
                else if (AccountNumber == transaction.ToAccountNumber)
                    funds += transaction.Amount;
            }

            return funds;
        }

        // Only used when generating bank statement
        public float CalculateFundsBeforeDateTime(DateTime dateTime)
        {
            float funds = 0f;

            foreach (Transaction transaction in BankData.Transactions)
            {
                if (transaction.TimeOfTransaction > dateTime)
                    return funds;

                if (AccountNumber == transaction.FromAccountNumber)
                {
                    funds -= transaction.Amount;
                    Console.WriteLine(transaction.Amount);
                }
                else if (AccountNumber == transaction.ToAccountNumber)
                    funds += transaction.Amount;
            }

            return funds;
        }

        public void TransferTo(Guid accountNumber, float amount)
        {
            if (amount <= 0)
                return;

            if (this is CurrentAccount)
                if (CalculateFunds() - amount < -((CurrentAccount)this).OverdraftAmount)
                    return;

            if (this is SavingsAccount)
                if (CalculateFunds() - amount < 0f)
                    return;

            Transaction transaction = new Transaction(AccountNumber, accountNumber, amount);

            BankData.Transactions.Add(transaction);
        }

        // Only manager can set branch
        public void SetBranch(Role role, Branch branch)
        {
            if (role == Role.Manager)
                Branch = branch;
        }

        public string GenerateBankStatement()
        {
            string bankStatement = $"\n{"date",-10} || {"credit",-8} || {"debit",-8} || {"balance",-8}\n";

            IEnumerable<Transaction> transactions = BankData.Transactions;

            foreach (Transaction trs in transactions.Reverse())
            {
                
                if (trs.ToAccountNumber != AccountNumber && trs.FromAccountNumber != AccountNumber)
                    continue;

                string time = trs.TimeOfTransaction.Date.ToShortDateString().ToString();

                string credit = "";
                string debit = "";

                if (trs.ToAccountNumber == AccountNumber)
                {
                    credit = trs.Amount.ToString();
                }
                else
                    debit = trs.Amount.ToString();

                string balance = CalculateFundsBeforeDateTime(trs.TimeOfTransaction).ToString();

                bankStatement += $"{time,-10} || {credit,-8} || {debit,-8} || {balance,-8}\n";
            }

            Console.WriteLine(bankStatement);

            return bankStatement;
        }

        public Guid AccountNumber { get; set; } = Guid.NewGuid();
        public Guid OwnerID { get; set; }
        public string AccountName { get; set; }
        public Branch? Branch { get; set; }
    }
}
