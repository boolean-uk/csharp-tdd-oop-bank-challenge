using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.BankAccountClasses;

namespace Boolean.CSharp.Main.Persons
{
    public class Customer : Person
    {
        public Customer(Bank bank, int id, string name) : base(bank, id, name)
        {

        }

        public void CreateAccount(string accountName)
        {
            Account account = new Account(accountName, ID);

            Bank.CreateAccount(account);
        }

        public void CreateSavingsAccount(string accountName)
        {
            SavingsAccount savingsAccount = new SavingsAccount(accountName, ID);

            Bank.CreateAccount(savingsAccount);
        }

        public void DepositToAccount(string accountName, decimal amount)
        {
            throw new NotImplementedException();
        }
        public void WithdrawFromAccount(string v1, int v2)
        {
            throw new NotImplementedException();
        }

        public void GenerateBankStatement(string accountName)
        {
            throw new NotImplementedException();
        }

        public object GetAccount(string accountName)
        {
            throw new NotImplementedException();
        }

    }
}
