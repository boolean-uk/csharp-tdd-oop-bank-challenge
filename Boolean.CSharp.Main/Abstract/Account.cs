using System;
using System.Collections.Generic;
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

        public void SetBranch(Role role, Branch branch)
        {
            if (role == Role.Manager)
                Branch = branch;
        }

        public string GenerateBankStatement()
        {
            throw new NotImplementedException();
        }

        public Guid AccountNumber { get; set; } = Guid.NewGuid();
        public Guid OwnerID { get; set; }
        public string AccountName { get; set; }
        public Branch? Branch { get; set; }
    }
}
