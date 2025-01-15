using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main.Abstract
{
    public abstract class Account
    {
        private Branch? _branch;

        public float CalculateFunds()
        {
            float funds = 0f;

            return funds;
        }

        public void TransferTo(float amount, Account account)
        {

        }

        public void SetBranch(Branch branch)
        {
            _branch = branch;
        }

        public Guid AccountNumber { get; set; } = Guid.NewGuid();
        public string Owner { get; set; }
        public string AccountName { get; set; }
        public Branch? Branch { get { return _branch; } }
        List<Transaction> transactions { get; set; }
    }
}
