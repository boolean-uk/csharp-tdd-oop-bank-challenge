using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        public List<Account> Accounts { get; }

        public Customer(List<Account> accounts) 
        {
            Accounts = accounts;
        }

        public void CreateSavingsAccount() { }

        public void CreateCurrentAccount() { }

        public void DepositToAccount(int accountID, decimal amount) 
        {
            Accounts[accountID].Deposit(amount);  
        }

        public string WithdrawFromAccount(int accountID, decimal amount) 
        {
            return Accounts[accountID].Withdraw(amount);
            
        }

        public string SeeBankStatement(int accountID)
        {
            return Accounts[accountID].BankStatement();
        }
    }
}
