using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface IStatement
    {
        public abstract string GenerateStatement(List<Transaction> transactions);
    }
}

