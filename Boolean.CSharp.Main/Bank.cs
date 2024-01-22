using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Bank
    {
        private BankStatementBuilder _bankStatementBuilder;
        public Bank(BankStatementBuilder bankStatementBuilder){
            _bankStatementBuilder = bankStatementBuilder;
        }
        public CurrentAccount CreateCurrentAccount(Customer customer, string accountname)
        {
            CurrentAccount newAccount = new CurrentAccount(accountname, _bankStatementBuilder);
            customer.AddAccount(newAccount);
            return newAccount;
        }

        public SavingsAccount CreateSavingsAccount(Customer customer, string accountname)
        {
            SavingsAccount newAccount = new SavingsAccount(accountname, _bankStatementBuilder);
            customer.AddAccount(newAccount);
            return newAccount;
            }
    }
}
