using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface IAdminestrator
    {
        public void RequestOverdraft(IAccount account);

        public void ApproveOverdraft(ICustomer user, IAccount account);

        public void DisableOverdraft(IAccount account);

        public int GetRequestedCount();

        public int GetApprovedCount();
    }
}
