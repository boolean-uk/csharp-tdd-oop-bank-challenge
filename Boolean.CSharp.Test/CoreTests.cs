using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Bank;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }

        [Test]
        public void CreateCurrentAccount()
        {
            // arrange
            string firstname = "clark";
            string lastname = "julie";
            string dob = "jan 1, 2009";           
            DateTime _dob = DateTime.Parse(dob);
            Customer customer = new Customer(firstname, lastname, _dob);
            Bank bank = new Bank();
            Guid guid = Guid.NewGuid();

            // act
            bool result = bank.CreateCurrentAccount(customer, out guid);
            int result2 = bank.accountDirectory[customer].Count();

            // assert
            Assert.That(result, Is.True);
            Assert.That(result2, Is.EqualTo(1));
        }

        [Test]
        public void CreateSavingsAccount()
        {
            // arrange
            string firstname = "clark";
            string lastname = "julie";
            string dob = "jan 1, 2009";
            DateTime _dob = DateTime.Parse(dob);
            Customer customer = new Customer(firstname, lastname, _dob);
            Bank bank = new Bank();
            Guid guid = Guid.NewGuid();

            // act
            bool result = bank.CreateSavingsAccount(customer, out guid);
            int result2 = bank.accountDirectory[customer].Count();

            // assert
            Assert.That(result, Is.True);
            Assert.That(result2, Is.EqualTo(1));
        }

        [Test]
        public void Deposit()
        {
            // arrange
            string firstname = "clark";
            string lastname = "julie";
            string dob = "jan 1, 2009";
            DateTime _dob = DateTime.Parse(dob);
            Customer customer = new Customer(firstname, lastname, _dob);
            Bank bank = new Bank();
            Guid guid = Guid.NewGuid();
            bool createAccount = bank.CreateSavingsAccount(customer, out guid);     


            // act
            bool result = bank.Deposit(guid, 1000, customer);

            Account account = bank.accountDirectory[customer][guid];

            // assert
            Assert.That(result, Is.True);
            Assert.That(account._balance, Is.EqualTo(1000));
        }


        [Test]
        public void GuidIsAdded()
        {
            // arrange
            string firstname = "clark";
            string lastname = "julie";
            string dob = "jan 1, 2009";
            DateTime _dob = DateTime.Parse(dob);
            Customer customer = new Customer(firstname, lastname, _dob);
            Bank bank = new Bank();
            Guid guid = new Guid();
            bool createAccount = bank.CreateSavingsAccount(customer, out guid);


            // act
            bool result = bank.Deposit(guid, 1000, customer);

            // assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Withdraw()
        {
            // arrange
            string firstname = "clark";
            string lastname = "julie";
            string dob = "jan 1, 2009";
            DateTime _dob = DateTime.Parse(dob);
            Customer customer = new Customer(firstname, lastname, _dob);
            Bank bank = new Bank();
            Guid guid = Guid.NewGuid();
            bool createAccount = bank.CreateSavingsAccount(customer, out guid);


            // act
            bool result = bank.Withdraw(guid, 1000, customer);

            Account account = bank.accountDirectory[customer][guid];

            // assert
            Assert.That(result, Is.True);
            Assert.That(account._balance, Is.EqualTo(-1000));
        }


    }
}