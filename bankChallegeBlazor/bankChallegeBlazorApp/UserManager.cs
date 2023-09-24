namespace Boolean.CSharp.Main
{
    public class UserManager
    {
        private List<User> users = new List<User>();
        private User loggedInUser;
        public string Register(string username, string password, string street, string postcode, string email, AllEnums.Branches branch)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "Password cannot be empty.";
            }

            var user = new User(username, password, street, postcode, email, branch);
            users.Add(user);

            return $"Welcome {username}! Your accounts have been created.";
        }

        public string Login(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                loggedInUser = user;
                return $"Welcome back {username}!";
            }
            else
            {
                return "Invalid credentials, try again.";
            }
        }

        public User GetLoggedInUser()
        {
            return loggedInUser;
        }
    }
}
