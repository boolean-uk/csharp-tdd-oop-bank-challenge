using Boolean.CSharp.Main.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Overdraft
    {
        public Account Account { get; set; }
        public double amount { get; set; }
        public Answer answer { get; set; } = Answer.DECLINED;
        public Transactions transactions { get; set; }

        public Overdraft(Account account, double amount, Answer answer, Transactions transactions)
        {
            this.Account = account;
            this.amount = amount;
            this.answer = answer;
            this.transactions = transactions;
        }
    }
}
