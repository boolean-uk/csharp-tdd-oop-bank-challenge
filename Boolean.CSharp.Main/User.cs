namespace Boolean.CSharp.Main
{
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }  // need to add hashing for password later
        public string Street { get; private set; }
        public string Postcode { get; private set; }
        public string Email { get; private set; }

        public User(string username, string password, string street, string postcode, string email)
        {
            Username = username;
            Password = password;  // Hash needs to be applied later
            Street = street;
            Postcode = postcode;
            Email = email;
        }
    }
}