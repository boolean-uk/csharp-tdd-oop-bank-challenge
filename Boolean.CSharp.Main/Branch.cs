using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Branch {
        public string BranchName { get; private set; }

        public Branch(string BranchName) {
            if (!string.IsNullOrEmpty(BranchName)) {
                this.BranchName = BranchName;
            } else {
                throw new Exception("Branchname can not be of empty string or null!!!");
            }
        }
    }
}