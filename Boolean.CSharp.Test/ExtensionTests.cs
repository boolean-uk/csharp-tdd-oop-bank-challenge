using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Abstract;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        private List<User> _users;
        private List<Account> _accounts;
        private List<OverdraftRequest> _overdraftRequests;
        private User _customerUser;
        private User _managerUser;
        private User _engineerUser;

        [SetUp]
        public void SetUp()
        {
            _users = new List<User>();
            _accounts = new List<Account>();
            _overdraftRequests = new List<OverdraftRequest>();

            // Create and add users
            _customerUser = new User(Main.Enums.Role.Customer, "Bob");
            _managerUser = new User(Main.Enums.Role.Manager, "Jeff");
            _engineerUser = new User(Main.Enums.Role.Engineer, "Harold");

            _users.Add(_customerUser);
            _users.Add(_managerUser);
            _users.Add(_engineerUser);
        }
    }
}
