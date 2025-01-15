
namespace Boolean.CSharp.Main.Classes
{
    public abstract class Person
    {
        public Guid PersonId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }

        protected Person(string firstName, string lastName, string email, string address)
        {
            PersonId = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}\n" +
                   $"Email: {Email}\n" +
                   $"Address: {Address}\n" +
                   $"Person ID: {PersonId}";
        }
    }
}
