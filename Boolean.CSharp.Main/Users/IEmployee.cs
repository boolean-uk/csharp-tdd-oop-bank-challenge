using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public interface IEmployee : IUser
    {
        void EvaluateOverdraftRequests(bool approval);

        string ShowOldestOverdraftRequest();

        void AddOverdraftRequest();
    }
}
