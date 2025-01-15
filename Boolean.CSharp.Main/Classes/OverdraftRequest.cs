
namespace Boolean.CSharp.Main.Classes
{
    public class OverdraftRequest
    {
        public Guid RequestId { get; private set; }
        public Customer Customer { get; private set; }
        public Account Account { get; private set; }
        public decimal RequestedAmount { get; private set; }
        public DateTime RequestDate { get; private set; }
        public bool IsApproved { get; private set; }
        public bool IsProcessed { get; private set; }

        public OverdraftRequest(Customer customer, Account account, decimal requestedAmount)
        {
            if (requestedAmount <= 0)
            {
                throw new ArgumentException("Requested amount must be greater than zero.");
            }

            RequestId = Guid.NewGuid();
            Customer = customer;
            Account = account;
            RequestedAmount = requestedAmount;
            RequestDate = DateTime.Now;
            IsApproved = false;
            IsProcessed = false;
        }

        public void Approve()
        {
            if (IsProcessed)
            {
                throw new InvalidOperationException("This request has already been processed.");
            }

            IsApproved = true;
            IsProcessed = true;

            Console.WriteLine($"Overdraft request approved for {Customer.FirstName} {Customer.LastName} on account {Account.AccountType}.");
        }

        public void Reject()
        {
            if (IsProcessed)
            {
                throw new InvalidOperationException("This request has already been processed.");
            }

            IsApproved = false;
            IsProcessed = true;

            Console.WriteLine($"Overdraft request rejected for {Customer.FirstName} {Customer.LastName} on account {Account.AccountType}.");
        }

        public decimal GetAmount() { return RequestedAmount; }

        public override string ToString()
        {
            return $"Overdraft Request ID: {RequestId}\n" +
                   $"Customer: {Customer.FirstName} {Customer.LastName}\n" +
                   $"Account Type: {Account.AccountType}\n" +
                   $"Requested Amount: {RequestedAmount:C}\n" +
                   $"Request Date: {RequestDate:dd/MM/yyyy}\n" +
                   $"Processed: {IsProcessed}\n" +
                   $"Approved: {IsApproved}";
        }
    }
}
