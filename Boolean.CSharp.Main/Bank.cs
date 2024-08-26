using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        public string Name { get; set; }

        public List<Branch> Branches { get; set; } = new List<Branch>();



        public void addBranch(Branch branch)
        {
            Branches.Add(branch);
        }

        public List<Branch> getBranches()
        {
            throw new NotImplementedException();
        }
    }
}
