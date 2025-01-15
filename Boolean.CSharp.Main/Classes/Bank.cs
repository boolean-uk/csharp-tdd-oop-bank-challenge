namespace Boolean.CSharp.Main.Classes
{
    public class Bank
    {
        public string Name { get; set; }
        public string Branch { get; set; }
        public List<Customer> Customers { get; set; }

        public Bank(string name, string branch)
        {
            Name = name;
            Branch = branch;
            Customers = new List<Customer>();
        }

        public Customer CreateCustomer(string firstName, string lastName, string email, string address)
        {
            var customer = new Customer(firstName, lastName, email, address, this);
            Customers.Add(customer);
            Console.WriteLine($"Customer created for {Name} and added to the branch {Branch}!");
            return customer;
        }
    }
}
