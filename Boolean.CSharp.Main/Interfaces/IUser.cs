using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface IUser
    {
        string firstName { get; set; }

        string phoneNumber { get; set; }
          string lastName { get; set; } 
        AccountType accountType { get; set; }
       

        decimal balance { get; set; }
    }
}
