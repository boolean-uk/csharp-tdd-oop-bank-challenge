using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Manager : Person
    {
        public Manager(string name, int id) : base(name, id) { }

        // Just a basic way to approve an overdraft request based on a prefixed rule...
        // In a real world scenario you would want to add more options, such as manual approval and such...
        public bool ApproveOverdraft(decimal amount, decimal balance)
        {
            decimal totalBalance = balance - amount;
            if (totalBalance <= -5000) return false;
            else return true;
        }
    }
}
