namespace Boolean.CSharp.Main
{
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Street { get; private set; }
        public string Postcode { get; private set; }
        public string Email { get; private set; }

        public User(string username, string password, string street, string postcode, string email)
        {
            Username = username;
            Password = BCrypt.Net.BCrypt.HashPassword(password); // used Bcrypt hashing for the password
            Street = street;
            Postcode = postcode;
            Email = email;
        }
    }
}