using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class StatementBuilder : IStatement
    {
        private StringBuilder _statementBuilder = new();

        private void BuildColumns() { throw new NotImplementedException(); }
        private void BuildStatements() { throw new NotImplementedException(); }
        public string GenerateStatement(List<Transaction> transactions)
        {
            throw new NotImplementedException();
        }
    }
}
