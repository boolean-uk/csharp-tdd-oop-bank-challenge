namespace Boolean.CSharp.Main.Classes
{
    public class Manager : Person
    {
        public Bank Bank { get; private set; }
        public string Branch => Bank.Branch;

        public Manager(string firstName, string lastName, string email, string address, Bank bank)
            : base(firstName, lastName, email, address)
        {
            Bank = bank;
        }

        public void ProcessOverdraftRequest(OverdraftRequest request, bool isApproved)
        {
            if (request.IsProcessed)
            {
                throw new InvalidOperationException("This overdraft request has already been processed.");
            }

            if (isApproved)
            {
                request.Approve();
                request.Account.SetOverdraftLimit(request.GetAmount());
            }
            else
            {
                request.Reject();
            }

            Console.WriteLine(isApproved
                ? $"Overdraft request approved for {request.Customer.FirstName} {request.Customer.LastName} on {request.Account.AccountType} account. Overdraft limit: {request.GetAmount():C}."
                : $"Overdraft request rejected for {request.Customer.FirstName} {request.Customer.LastName} on {request.Account.AccountType} account.");
        }
    }
}
