using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Interfaces;
using Boolean.CSharp.Main.Misc;

namespace Boolean.CSharp.Main
{
    public class ConsoleWriter : IStatementWriter
    {
        public int ColumnSize { get; set; } = 12;
        public string Seperator { get; set; } = "||";
        public bool IncludeEdges { get; set; } = false;
        public void WriteStatement(List<AccountTransaction> transactions)
        {
            StringBuilder sb = new StringBuilder();
            List<string> rows = [];
            sb.AppendLine(StringHelper.Columnify(["date", "credit", "debit", "balance"], ColumnSize));
            double runningTotal = 0;
            foreach (var transaction in transactions.OrderBy(t => t.Created))
            {
                runningTotal += transaction.Amount;
                string credit = transaction.Amount > 0 ? transaction.Amount.ToString() : "";
                string debit = transaction.Amount < 0 ? (-transaction.Amount).ToString() : "";
                rows.Add(StringHelper.Columnify(
                    [transaction.Created.ToString("dd/MM/yyyy"), credit, debit, runningTotal.ToString()],
                    ColumnSize,
                    Seperator,
                    IncludeEdges
                ));
            }
            rows.Reverse();
            rows.ForEach(row => sb.AppendLine(row));
            Console.Out.WriteLine(sb.ToString());
        }
    }
}
