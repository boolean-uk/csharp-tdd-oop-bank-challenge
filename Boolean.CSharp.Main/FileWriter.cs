using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Interfaces;
using Boolean.CSharp.Main.Misc;

namespace Boolean.CSharp.Main
{
    public class FileWriter : IStatementWriter
    {
        public int ColumnSize { get; set; } = 12;
        public string Seperator { get; set; } = "||";
        public bool IncludeEdges { get; set; } = false;
        public string SavePath { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string FileName { get; set; } = "account_statement.txt";
        public void WriteStatement(List<AccountTransaction> transactions)
        {
            List<string> rows = [];
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
            rows.Add(StringHelper.Columnify(["date", "credit", "debit", "balance"], ColumnSize));
            rows.Reverse();

            using StreamWriter outputFile = new StreamWriter(Path.Combine(SavePath, FileName));
            foreach (string row in rows)
                outputFile.WriteLine(row);
            Console.WriteLine($"Wrote statement to file '{Path.Combine(SavePath, FileName)}'.");
        }
    }
}
