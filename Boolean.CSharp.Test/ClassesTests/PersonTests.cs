using NUnit.Framework;
using System;
using Boolean.CSharp.Main.Classes;

namespace Boolean.CSharp.Test
{
    public class PersonTestClass : Person
    {
        public PersonTestClass(string firstName, string lastName, string email, string address)
            : base(firstName, lastName, email, address) { }
    }

    public class PersonTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPersonConstructor()
        {
            string firstName = "Jone";
            string lastName = "Hjorteland";
            string email = "jonehjorteland@experis.no";
            string address = "Vestre Strømkaien 13, 5008 Bergen";

            var person = new PersonTestClass(firstName, lastName, email, address);

            Assert.AreEqual(firstName, person.FirstName);
            Assert.AreEqual(lastName, person.LastName);
            Assert.AreEqual(email, person.Email);
            Assert.AreEqual(address, person.Address);
            Assert.IsNotNull(person.PersonId);
        }

        [Test]
        public void TestToStringMethod()
        {
            string firstName = "Jone";
            string lastName = "Hjorteland";
            string email = "jonehjorteland@experis.no";
            string address = "Vestre Strømkaien 13, 5008 Bergen";
            var person = new PersonTestClass(firstName, lastName, email, address);

            string result = person.ToString();

            Assert.IsTrue(result.Contains(firstName));
            Assert.IsTrue(result.Contains(lastName));
            Assert.IsTrue(result.Contains(email));
            Assert.IsTrue(result.Contains(address));
            Assert.IsTrue(result.Contains(person.PersonId.ToString()));
        }
    }
}
