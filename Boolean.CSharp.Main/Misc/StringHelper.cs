using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Misc
{
    public static class StringHelper
    {
        public static string Columnify(List<string> columns, int columnSize, string seperator = "||", bool includeEdges = false)
        {
            StringBuilder sb = new StringBuilder();
            if (includeEdges) sb.Append(seperator + " ");
            columns.ForEach(column =>
            {
                sb.Append(column);
                if (column.Length < columnSize)
                {
                    sb.Append(new string(' ', columnSize - column.Length));
                }
                sb.Append(" " + seperator + " ");
            });
            if (includeEdges) sb.Length--;
            else sb.Length -= seperator.Length + 2;
            return sb.ToString();
        }
    }
}
