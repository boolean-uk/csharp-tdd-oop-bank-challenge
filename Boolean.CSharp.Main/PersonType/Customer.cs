using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Interface;
using NUnit.Framework;

namespace Boolean.CSharp.Main.PersonType
{
    public class Customer
    {
    
        public decimal accountBalance { get; set; }
        string name { get; set; }
        List<IAccount> accounts = new List<IAccount>();
        

        public Customer(string _name)
        {
            name = _name;
        }


        public int GetAccountsCount()
        {
            return accounts.Count;
        }

        public void CreateAccount(string type, string name)
        {
            string toLower = type.ToLower();

            if (toLower == "checkings")
            {
                accounts.Add(new Checkings(name));
            }

            else if (toLower == "savings")
            {
                accounts.Add(new Savings(name));
            }

            else
            {
                throw new Exception("We don't offer that type of account");
            }
        
        }

        public void Withdrawal(ITransaction transaction, decimal amount, bool hasOverdraft, IAccount account)
        {

            if (!hasOverdraft && amount > account.accountBalance)
            { 
                    throw new Exception($"You don't have enough in your balance to withdraw the £{amount}");
                }

                if (hasOverdraft && amount > accountBalance || amount < account.accountBalance)
                {
                    account.accountBalance -= amount;
                    account.AddTransaction(transaction);
                }
            }

        public IAccount GetAccount(string name)
        {
            foreach (IAccount account in accounts)
            {
                if (account.name == name)
                {
                    return account;
                }
            }
            throw new Exception($"There is no account associated with {name}.");
        }


        public void Deposit(decimal amount, IAccount account)
        {
            account.accountBalance += amount;
            account.AddTransaction(new CreditTransaction(amount));
        }

        public void PrintBankStatement(IAccount account)
        {


        }


    }
}
