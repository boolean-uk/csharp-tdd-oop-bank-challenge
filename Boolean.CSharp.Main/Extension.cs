
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace Boolean.CSharp.Main
{
    public class Extension
    {
        private Core _core;


        public class BankBranch // Extension User Story 2
        {
            private string branchId;
            private string branchName;
            private string location;

            public BankBranch(string branchId, string branchName, string location)
            {
                this.branchId = branchId;
                this.branchName = branchName;
                this.location = location;
            }

            public string BranchId { get => branchId; set => branchId = value; }
            public string BranchName { get => branchName; set => branchName = value; }
            public string Location { get => location; set => location = value; }
        }

        public class BankAccount : Core.BankAccount
        {
            private BankBranch accountBranch; // Extension User Story 2
            private double overdraftLimit;

            public BankAccount(string accountHolder, string accountNumber, string accountType, BankBranch accountBranch, double balance)
                : base(accountHolder, accountNumber, accountType)
            {
                this.accountBranch = accountBranch;
            }

            public BankBranch AccountBranch
            {
                get => accountBranch;
                set => accountBranch = value;
            }

            public double OverdraftLimit
            {
                get => overdraftLimit;
                set => overdraftLimit = value;
            }

            // Extension User Story 1
            public new double GetBalance
            {
                get
                {
                    double calculatedBalance = 0;

                    foreach (var transaction in TransactionList)
                    {
                        if (transaction.Type == "Deposit")
                        {
                            calculatedBalance += transaction.Amount;
                        }
                        else if (transaction.Type == "Withdrawal")
                        {
                            calculatedBalance -= transaction.Amount;
                        }
                    }

                    return calculatedBalance;
                }
            }


            // Extension User Story 3
            public bool RequestOverdraft(double limit)
            {
                this.overdraftLimit = limit;
                return true; // Approved
            }

            // Extension User Story 4
            public bool ApproveOverdraft(BankAccount account, double limit)
            {
                if (account.GetBalance >= 0)
                {
                    account.RequestOverdraft(limit);
                    return true; // Approved
                }
                return false; // Rejected
            }

        }

        public class MessageNotification
        {
            // Extension User Story 5
            public string SendStatement(BankAccount account)
            {
                if (!account.TransactionList.Any())
                {
                    return "No transactions available to generate a statement.";
                }

                var bankStatement = new Core.BankStatement();
                string statement = bankStatement.GenerateBankStatement(account);
                return $"Statement sent to customer:{Environment.NewLine}{statement}";
            }

        }

    }
    
}
