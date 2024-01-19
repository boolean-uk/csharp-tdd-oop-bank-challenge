namespace Boolean.CSharp.Main
{
    public class User
    {
        public Account CreateCurrent()
        {
            return new CurrentAccount();
        }

        public Account CreateSavings()
        {
            return new SavingsAccount();
        }
    }

    public class Account
    {
        private float balance = 0f;
        private List<Transaction> transactions = new List<Transaction>();

        public float GetBalance()
        {
            return balance;
        }

        public bool DepositMoney(float amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Transaction newTrans = new Transaction(amount, balance, true);
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
            if (amount <= balance && amount > 0)
            {
                balance -= amount;
                Transaction newTrans = new Transaction(amount, balance, false);
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
            List<string> transactionOutput = new List<string>();
            transactionOutput.Add("date\t\t||credit||debit\t||balance");

            for (int i = transactions.Count - 1; i >= 0; i--)
            {
                var date = transactions[i].transactionDate.ToString("dd-MM-yyyy");
                string credit = "";
                string debit = "";
                if (transactions[i].IsCredit)
                {
                    credit = transactions[i].Amount.ToString();
                }
                else
                {
                    debit = transactions[i].Amount.ToString();
                }
                var balance = transactions[i].balance.ToString();
                transactionOutput.Add($"{date}\t||{credit}\t||{debit}\t||{balance}");
            }
            foreach (var item in transactionOutput)
            {
                Console.WriteLine(item);

            }
            return transactionOutput;
        }
    }

    public class CurrentAccount : Account
    {

    }
    public class SavingsAccount : Account
    {

    }

    public struct Transaction
    {
        public float Amount { get; }
        public float balance { get; }
        public bool IsCredit { get; }
        public DateTime transactionDate { get; }
        public Transaction(float amount, float balance, bool isCredit)
        {
            this.Amount = amount;
            this.balance = balance;
            this.IsCredit = isCredit;
            this.transactionDate = DateTime.Today;
        }
    }
}
