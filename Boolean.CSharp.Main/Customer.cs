
namespace Boolean.CSharp.Main
{
    public class Customer
    {
        private string _name;
        private string _phone;

        public Customer(string name, string phone)
        {
            _name = name;
            _phone = phone;
        }
        public string GetName()
        {
            return _name;
        }
        public string GetPhone() { return _phone; }
    }
}
