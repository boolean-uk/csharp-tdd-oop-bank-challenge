using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Communication;
using Boolean.CSharp.Main.Models.Transactions;

namespace Boolean.CSharp.Main.Models.Accounts
{
    public class SavingsAccount : IAccount
    {

        public SavingsAccount(Branch branch, string accountName)
        {
            Branch = branch;
            AccountName = accountName;
            AccountNumber = Guid.NewGuid().ToString();
            Transactions = new List<ITransaction>();
            BankStatements = new List<BankStatement>();
            OverdraftRequests = new List<OverdraftRequest>();

        }

        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public Branch Branch { get; set; }
        public List<BankStatement> BankStatements { get; set; }
        public List<OverdraftRequest> OverdraftRequests { get; set; }
        public List<ITransaction> Transactions { get; set; }
        public decimal GetBalance()
        {
            return Transactions.Last().Balance;
        }
        public DebitTransaction Deposit(decimal amount)
        {
            DebitTransaction transaction = new DebitTransaction(amount, Transactions.Last().Balance);
            Transactions.Add(transaction);
            return transaction;
        }
        public CreditTransaction Withdraw(decimal amount)
        {
            CreditTransaction transaction = new CreditTransaction(amount, Transactions.Last().Balance);
            Transactions.Add(transaction);
            return transaction;
        }
        public OverdraftRequest RequestOverdraft(decimal amount)
        {
            OverdraftRequest request = new OverdraftRequest(amount);
            OverdraftRequests.Add(request);
            return request;
        }
        public decimal GetOverdraftLimit()
        {
            return OverdraftRequests.Where(x => x.Approved).Last().Amount;
        }

        public BankStatement CreateBankStatement()
        {
            BankStatement statement = new BankStatement(Transactions);
            BankStatements.Add(statement);
            return statement;
        }
        public void sendBankStatement(ICommunicator communicator)
        {
            BankStatement statement = CreateBankStatement();
            communicator.Send(statement.getStatementString());
        }
    }
}
