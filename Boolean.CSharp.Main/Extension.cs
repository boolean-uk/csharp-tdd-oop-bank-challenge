
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
            branches.Add(1, "UK");
            branches.Add(2, "SWE");
            branches.Add(3, "NOR");
            }

            public Dictionary<int, string> GetBranches()
            {
                return branches;
            }

            public bool CheckIfBranchExists(int id)
            {
                if (branches.ContainsKey(id)) { return true; }
                return false;
            }

            public bool CheckIfBranchExists(string location)
            {
            if (branches.ContainsValue(location)) { return true; }
            return false;
            }


            public string GetBranchNameById(int id) {
                if(branches.TryGetValue(id, out string BranchName)) { return BranchName; };
                return "BRANCH DOES NOT EXIST."; 

            }
        }

        public interface Iaccount
        {
            public List<Transaction> GetTransactions();
            public bool AddTransaction(float f, DateTime? date);
            public float GetBalance();
            string GenerateTransationsHistory();
            //EXTENSION
            bool UpdateBranch(int branch);
            bool RequestOverdraft(float amt);
            bool ApproveOverdraftRequest();
            bool DenyOverdraftRequest();
            public string BranchName();
        }
        public class Account : Iaccount
        {
            private Bank bank;
            private List<Transaction> transactions;
            public List<Transaction> Transactions { get { return transactions; } }

            private Transaction? OverdraftRequest;
            private int branchId;
            public string BranchName() { return bank.GetBranchNameById(branchId); }

            public Account(Bank bank, int branch_id)
            {
                transactions = new List<Transaction>();

                this.bank = bank;
                this.branchId = branch_id;
            }

            public bool UpdateBranch(int branchId)
            {
            if (bank.CheckIfBranchExists(branchId)) 
                { 
                this.branchId = branchId;
                return true;
                };
            return false;
            }

            public bool RequestOverdraft(float amount)
            {
                if(OverdraftRequest != null) { return false; }
                
                OverdraftRequest = new Transaction(DateTime.Now, amount);
                return true;
            }
            public bool ApproveOverdraftRequest()
            {
            if (OverdraftRequest == null) { return false; }

            transactions.Add(OverdraftRequest.Value);
            return true;
            
            }
            public bool DenyOverdraftRequest()
            {
                if (OverdraftRequest == null) { return false; }

                OverdraftRequest = null;
                return true;

            }

        public bool AddTransaction(float transactionAmount, DateTime? date)
            {
                if (transactionAmount == 0f ) { return false; }

                if ( GetBalance() + transactionAmount < 0f ) { return false; }

                if (date != null)
                {
                    transactions.Add(new Transaction(date.Value, transactionAmount)); return true;

                }

                transactions.Add(new Transaction(DateTime.Now, transactionAmount)); return true;
            }


            public float GetBalance()
            {
                float balance = 0;

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
