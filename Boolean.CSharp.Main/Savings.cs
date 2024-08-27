using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Savings : Account
    {
        public Savings(string accountNr, string type, string branch, double balance) : base(accountNr, type, branch, balance)
        {
        }

        public string AccountNr { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Branch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string OwnerName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Balance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
