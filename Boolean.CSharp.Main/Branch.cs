using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Branch
    {
        public string Name = string.Empty;
        public List<ICustomer> users;
        public int Id = 0;
        public Branch(Enum location) {
            users = new List<ICustomer>();
            Name = location.ToString();
            Id = location.GetHashCode();
        }

        public void AddUser(ICustomer user)
        {
            user.Branch = Id;
            users.Add(user);
        }
    }

}
