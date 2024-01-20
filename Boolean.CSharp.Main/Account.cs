namespace Boolean.CSharp.Main
{
    public class Account
    {
        public BranchCode BranchCode { get; }
        private List<Transaction> transactions;
        private Queue<Transaction> overdraftRequests;

        public Account(BranchCode branchCode)
        {
            this.BranchCode = branchCode;
            transactions = new List<Transaction>();
            overdraftRequests = new Queue<Transaction>();
        }

        public float GetBalance()
        {
            float balance = 0f;
            foreach (var item in transactions)
            {
                if (item.IsCredit)
                {
                    balance += item.Amount;
                }
                else if (!item.IsCredit)
                {
                    balance -= item.Amount;
                }
                else
                {
                    throw new Exception("Get balance Is credit error");
                }
            }
            return balance;
        }

        public bool DepositMoney(float amount)
        {
            if (amount > 0)
            {
                //balance += amount;
                Transaction newTrans = new Transaction(amount, true);
                transactions.Add(newTrans);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool WithdrawMoney(float amount)
        {
            if (amount <= GetBalance() && amount > 0)
            {
                //balance -= amount;
                Transaction newTrans = new Transaction(amount, false);
                transactions.Add(newTrans);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> GenerateBankStatement()
        {
            float balance = GetBalance();
            List<string> transactionOutput = new List<string>();
            transactionOutput.Add("date\t\t||credit||debit\t||balance");

            for (int i = transactions.Count - 1; i >= 0; i--)
            {
                float tempBalance = balance;
                var date = transactions[i].transactionDate.ToString("dd-MM-yyyy");
                string credit = "";
                string debit = "";
                if (transactions[i].IsCredit)
                {
                    credit = transactions[i].Amount.ToString();
                    balance -= transactions[i].Amount;

                }
                else
                {
                    debit = transactions[i].Amount.ToString();
                    balance += transactions[i].Amount;
                }
                transactionOutput.Add($"{date}\t||{credit}\t||{debit}\t||{tempBalance}");
                tempBalance = balance;
            }

            foreach (var item in transactionOutput)
            {
                Console.WriteLine(item);
            }
            return transactionOutput;
        }

        public bool OverdraftMoney(float amount)
        {
            throw new NotImplementedException();
        }

        public bool CancelOverdraft()
        {
            throw new NotImplementedException();
        }

    }

    public class CurrentAccount : Account
    {
        public CurrentAccount(BranchCode branchCode) : base(branchCode) { }

    }
    public class SavingsAccount : Account
    {
        public SavingsAccount(BranchCode branchCode) : base(branchCode) { }
    }
}

public enum BranchCode
{
    LOND,
    STOC,
    NEWY,
    MADR
}


