using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Bank
{
    public  class Branch : Account
    {
        private string _branchName;

        public Branch() 
        {
            BranchName = _branchName;   
        }
        public override string BranchName { get => base.BranchName; set => base.BranchName = _branchName; }

    }

}
