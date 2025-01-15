
using System.Text;

namespace Boolean.CSharp.Main.Classes
{
    public class Account
    {
        public Guid AccountId { get; private set; }
        public string AccountType { get; private set; }
        public decimal Balance { get; private set; }
        public Customer Owner { get; private set; }
        public string Branch { get; private set; }
        private List<Transaction> Transactions { get; set; }
        private decimal OverdraftLimit { get; set; }

        public Account(string accountType, Customer owner, string branch)
        {
            if (accountType != "Current" && accountType != "Savings")
            {
                throw new ArgumentException("Account type must be either 'Current' or 'Savings'");
            }

            AccountId = Guid.NewGuid();
            AccountType = accountType;
            Owner = owner;
            Branch = branch;
            Balance = 0m;
            Transactions = new List<Transaction>();
            OverdraftLimit = 0m;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }

            Balance += amount;
            Transactions.Add(new Transaction("Deposit", amount, Balance));
            Console.WriteLine($"Deposited {amount:C} to (AccountID: {AccountId}, AccountType: {AccountType}) account. New balance: {Balance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            if (GetBalance() + OverdraftLimit < amount)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }

            Transactions.Add(new Transaction("Withdrawal", amount, GetBalance() - amount));
            Console.WriteLine($"Withdrew {amount:C} from (AccountID: {AccountId}, AccountType: {AccountType}) account. New balance: {GetBalance():C}");
        }

        public decimal GetBalance()
        {
            return Transactions.Sum(transaction =>
                transaction.Type == "Deposit" ? transaction.Amount : -transaction.Amount);
        }

        public OverdraftRequest RequestOverdraft(decimal amount)
        {
            OverdraftRequest overdraftRequest = new OverdraftRequest(Owner, this, amount);
            return overdraftRequest;
        }

        public void SetOverdraftLimit(decimal limit)
        {
            if (limit < 0)
            {
                throw new ArgumentException("Overdraft limit cannot be negative.");
            }
            OverdraftLimit = limit;
            Console.WriteLine($"Overdraft limit set to {OverdraftLimit:C} for (AccountID: {AccountId}, AccountType: {AccountType}).");
        }

        public void DisplayAccountDetails()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"AccountID: {AccountId}");
            Console.WriteLine($"Account Type: {AccountType}");
            Console.WriteLine($"Account Owner: {Owner.FirstName} {Owner.LastName}");
            Console.WriteLine($"Branch: {Branch}");
            Console.WriteLine($"Balance: {Balance:C2}");
            Console.WriteLine("------------------------------------------------------------");
        }

        public string GenerateStatement()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Bank Statement for {Owner.FirstName} {Owner.LastName} (AccountID: {AccountId}, AccountType: {AccountType})");
            sb.AppendLine("------------------------------------------------------------");
            sb.AppendLine($"{"Date",-12}{"Transaction Type",-15}{"Amount",-20}{"Balance"}");
            sb.AppendLine("------------------------------------------------------------");

            foreach (var transaction in Transactions)
            {
                sb.AppendLine($"{transaction.Date.ToString("dd.MM.yyyy"),-12}" +
                              $"{transaction.Type,-15}" +
                              $"{transaction.Amount.ToString("C2"),-20}" +
                              $"{transaction.Balance.ToString("C2")}");
            }

            sb.AppendLine("------------------------------------------------------------");

            return sb.ToString();
        }

        public void DisplayStatement()
        {
            Console.WriteLine(GenerateStatement());
        }
    }
}
