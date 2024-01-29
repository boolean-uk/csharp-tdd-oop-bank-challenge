using Boolean.CSharp.Main.Branch;
using Boolean.CSharp.Main.MessageProvider;
using Boolean.CSharp.Main.Transactions;
using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class SavingsAccount : PersonalAccount
    {
        public SavingsAccount(Customer user) : base(user)        {
        }

        /// <inheritdoc />
        /// <remarks> Will always return 0 as a SavingsAccount does not allow for overdrafting of the account  </remarks>
        public override decimal SetOverdrawLimit(decimal limit, IUser user)
        {
            return 0m;
        }

        /// <inheritdoc />
        /// <remarks> SavingsAccount does not allow for overdrafting the account balance</remarks>
        public override decimal Withdraw(decimal amount)
        {
            if (base.GetBalance() > amount)
            {
                base.GetTransactionManager().AddWithdrawTransaction(amount);
                return amount;
            }
            else
            {
                return 0m;
            }
        }
    }
}
