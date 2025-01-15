using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Branch Branch { get; set; }



        public Account(string firstName, string lastName, Branch branch)

        {

            FirstName = firstName;
            LastName = lastName;
            Branch = branch;

        }

        public string showAccountInfo()
        {
            return FirstName + LastName + Branch;
        }

    }
}
