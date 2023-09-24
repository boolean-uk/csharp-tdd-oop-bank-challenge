namespace Boolean.CSharp.Main
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
        public SavingsAccount UserSavingsAccount { get; set; }
        public CurrentAccount UserCurrentAccount { get; set; }

        public User() { }

        public User(string username, string password, string street, string postcode, string email, AllEnums.Branches branch)
        {
            Username = username;
            Password = BCrypt.Net.BCrypt.HashPassword(password);
            Street = street;
            Postcode = postcode;
            Email = email;
            UserSavingsAccount = new SavingsAccount(branch, this); // Initialize Savings account on registration
            UserCurrentAccount = new CurrentAccount(branch, this); // Initialize Current account on registration
        }
    }
}
