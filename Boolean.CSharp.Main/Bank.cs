using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountType;

namespace Boolean.CSharp.Test
{
    public class Bank
    {
        public List<Branch> BranchList { get; set; }

        public Bank()
        {
            BranchList = new List<Branch>();
        }

    }
}