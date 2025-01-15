using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Misc;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class StringHelperTest
    {
        [TestCase("1   || 2   || 3  ", 3, "||", false, "1", "2", "3")]
        [TestCase("|| 1   || 2   || 3   ||", 3, "||", true, "1", "2", "3")]
        [TestCase("| date       | credit     | debit      | balance    |", 10, "|", true, "date", "credit", "debit", "balance")]
        [TestCase("| date   | credit | debit  | balance |", 6, "|", true, "date", "credit", "debit", "balance")]
        public void TestStringHelperColumnify(string expected, int columnSize, string seperator, bool includeEdges, params string[] columns)
        {
            string result = StringHelper.Columnify([.. columns], columnSize, seperator, includeEdges);
            Assert.AreEqual(expected, result);
        }
    }
}
