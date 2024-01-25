using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Miscellaneous
{
    public class ReceiptBuilder
    {
        private List<string> rows;
        private int minColumnWidth;
        private string[] columns;

        public ReceiptBuilder(int columnWidth = 20)
        {
            minColumnWidth = 2;
            if (columnWidth > 0) ColumnWidth = columnWidth;
            else ColumnWidth = minColumnWidth;
            rows = new List<string>();
            Seperator = "||";
            columns = new string[]{};
        }

        public void AddRow(params string[] inputs)
        {
            rows.Add(BuildReceiptLine(inputs));
        }

        public string GenerateReceipt()
        {
            rows.Insert(0, BuildReceiptLine(columns));
            StringBuilder receipt = new StringBuilder();
            foreach (string line in rows) receipt.AppendLine(line);
            return receipt.ToString();
        }

        private string BuildReceiptLine(string[] inputs)
        {
            string receiptLine = "";
            for (int i = 0; i < inputs.Length; i++)
            {
                receiptLine += BuildReceiptCell(inputs[i]);
                if (i < inputs.Length - 1) receiptLine += Seperator;
            }
            return receiptLine;
        }

        private string BuildReceiptCell(string input)
        {
            if (input.Length > ColumnWidth - 2)
            {
                return "  " + input.Substring(0, ColumnWidth - 5) + ".  ";
            }
            return "  " + input + new string(' ', ColumnWidth - input.Length - 2);
        }

        public int ColumnWidth { get; set; }
        public string[] Columns { get => columns; set => columns = value.Select(s => s.ToUpper()).ToArray(); }
        public string Seperator {  get; set; }
    }
}
