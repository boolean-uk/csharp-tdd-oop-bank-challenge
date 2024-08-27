using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Savings : Account
    {
        public Savings(Branch branch, string accountNr, string type, double balance) : base(branch, accountNr, type, balance)
        {
        }

        

        public string AccountNr { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Branch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string OwnerName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Balance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
