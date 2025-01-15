using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface IStatementWriter
    {
        void WriteStatement(List<AccountTransaction> transactions);
    }
}
