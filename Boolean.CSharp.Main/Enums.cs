using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public enum TransactionType
    {
        Debit,
        Credit
    }
    public enum Branch
    {
        Athens, 
        Oslo,
        Amsterdam,
        EnglandsCalifornia
    }
    public enum OverDraftRequestStatus
    {
        Pending,
        Denied,
        Approved
    }
}
