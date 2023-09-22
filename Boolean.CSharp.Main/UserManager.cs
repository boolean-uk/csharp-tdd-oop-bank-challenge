namespace Boolean.CSharp.Main
{
    public class UserManager
    {
        private List<User> users = new List<User>();

        public User Register()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be empty.");
            }

            Console.WriteLine("Enter street:");
            string street = Console.ReadLine();

            Console.WriteLine("Enter postcode:");
            string postcode = Console.ReadLine();

            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();

            var user = new User(username, password, street, postcode, email);
            users.Add(user);

            Console.WriteLine($"Welcome {username}! Your account has been created.");
            return user;
        }

        public User Login()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            var user = users.FirstOrDefault(u => u.Username == username);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password)) //for verifying the provided password with the stored hashed password
            {
                Console.WriteLine($"Welcome back {username}!");
                return user;
            }
            else
            {
                Console.WriteLine("Invalid credentials, try again.");
                return null;
            }
        }
    }
}
