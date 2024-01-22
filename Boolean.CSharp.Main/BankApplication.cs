using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class BankApplication
    {
        private Dictionary<int, IUsers> _listUsers = new Dictionary<int, IUsers>();

        public void Add(Custommer custommer1)
        {
            _listUsers.Add(custommer1.Id, custommer1);
        }

        public Dictionary<int,IUsers> seeUsers()
        {
            return _listUsers;
        }
    }
}
