namespace Boolean.CSharp.Main
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string SortCode { get; set; }
        public List<Account> Accounts { get; private set; }

        public Branch(int id , string name , string address , string sortCode)
        {
            Id = id;
            Name = name;
            Address = address;
            SortCode = sortCode;
            Accounts = new List<Account>();
        }

        public bool AddAccount(Account account)
        {
            if(account == null) return false;

            Accounts.Add(account);
            return true;
        }

        public bool RemoveAccount(int accountId)
        {
            var account = Accounts.Find(a => a.Id == accountId);
            if(account == null) return false;

            Accounts.Remove(account);
            return true;
        }

        public bool ApproveOverdraftRequest(int accountId , float amount)
        {
            var account = Accounts.Find(a => a.Id == accountId) as CurrentAccount;
            if(account == null) return false;

            account.OverdraftLimit = amount;
            return true;
        }
    }
}
