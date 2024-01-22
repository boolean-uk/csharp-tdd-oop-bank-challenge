
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Extension
{


        public class Bank
        {
            private Dictionary<int, string> branches;

            public Bank()
            {
                branches = new Dictionary<int, string>();
            }

            public Dictionary<int, string> GetBranches()
            {
                throw new NotImplementedException();
            }

            public bool CheckIfBranchExists(int id)
            {
                throw new NotImplementedException();
            }

            public bool CheckIfBranchExists(string location)
            {
                throw new NotImplementedException();
            }


            public string GetBranchNameById(int id) {  throw new NotImplementedException();}
        }

        public interface Iaccount
        {
            public List<Transaction> GetTransactions();
            public bool AddTransaction(float f, DateTime? date);
            public float GetBalance();
            string GenerateTransationsHistory();
        }
        public class Account : Iaccount
        {
            private Bank bank;
            private List<Transaction> transactions;
            public List<Transaction> Transactions { get { return transactions; } }

            private Transaction? OverdraftRequest;
            private int branchId;
            public string BranchName { get { return bank.GetBranchNameById(branchId); } }

            public Account(Bank bank, int branch_id)
            {
                transactions = new List<Transaction>();

                throw new NotImplementedException();
            }

            public bool UpdateBranch(string branch)
            {
                throw new NotImplementedException();
            }

            public bool RequestOverdraft(float amount)
            {
                throw new NotImplementedException();
            }
            public bool ApproveOverdraftRequest()
            {
                throw new NotImplementedException();
            }
            public bool DenyOverdraftRequest()
            {
                throw new NotImplementedException();
            }

            public bool AddTransaction(float transactionAmount, DateTime? date)
            {
                if (transactionAmount == 0f) { return false; }

                if (date != null)
                {
                    transactions.Add(new Transaction(date.Value, transactionAmount)); return true;

                }

                date = (DateTime?)DateTime.Now;
                transactions.Add(new Transaction(date.Value, transactionAmount)); return true;
            }


            public float GetBalance()
            {
                float balance = 3;

                balance += transactions.Aggregate(0f, (tot, next) => tot + next.Amount);

                return balance;

            }

            public List<Transaction> GetTransactions() { return transactions; }

            public string GenerateTransationsHistory()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("date || credit || debit || balance\n");
                float total = GetBalance();
                string div = " || ";
                string floatFormatting = "{0:0.00}";

                foreach (Transaction t in transactions.OrderByDescending(t => t.CreationDate))
                {
                    sb.Append(t.CreationDate.Day + " / " + string.Format("{0:00}", t.CreationDate.Month) + " / " + t.CreationDate.Year);
                    sb.Append(div);

                    if (t.Amount >= 0) { sb.Append(string.Format(floatFormatting, t.Amount)); } else { sb.Append(""); };

                    sb.Append(div);

                    if (t.Amount <= 0) { sb.Append(string.Format(floatFormatting, Math.Abs(t.Amount))); } else { sb.Append(""); };

                    sb.Append(div);

                    sb.Append(string.Format(floatFormatting, total));
                    total -= t.Amount;




                    sb.Append('\n');
                }
                Console.WriteLine(sb.ToString());

                return sb.ToString().Replace(",", ".");

            }

        }

        public class SavingsAccount : Account
        {
            public SavingsAccount(Bank bank, int branch_id) : base(bank, branch_id) { }
        }

        public class CurrentAccount : Account
        {
            public CurrentAccount(Bank bank, int branch_id) : base(bank, branch_id) { }
        }

        public struct Transaction
        {
            public DateTime CreationDate;
            public float Amount;
            public Transaction(DateTime creationDate, float amount)
            {
                CreationDate = creationDate;
                Amount = amount;
            }
        }
    
}
