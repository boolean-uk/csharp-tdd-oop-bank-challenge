using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Boolean.CSharp.Main.Class;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interface;
using Transaction = Boolean.CSharp.Main.Class.Transaction;

namespace Boolean.CSharp.Main.Abstract
{
    public class OverdraftRequest : Request
    {
        public OverdraftRequest(Account account) : base(ref account)
        {
        }
        public bool Overdraft(decimal amount)
        {

            if (Account is IOverdraftable overdraftable && Account.CalculateBalance() - amount > -overdraftable.OverdraftLimit)
            {
                return true;
            }
            return false;
        }

    }
}
