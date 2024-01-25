using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Miscellaneous;
using Boolean.CSharp.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.BankStatements
{
    public class SimpleBankStatement : IBankStatement
    {
        private BankAccount account;

        public SimpleBankStatement(BankAccount account)
        {
            this.account = account;
        }

        public string GenerateStatement()
        {
            ReceiptBuilder receipt = new ReceiptBuilder();
            receipt.Columns = ["date", "credit", "debit", "balance"];
            decimal balance = 0;
            foreach(ITransaction t in this.account.Transactions.GetTransactions())
            {
                string credit = (t.EffectOnBalance() > 0) ? t.Amount.ToString() : "";
                string debit = (t.EffectOnBalance() <= 0) ? t.Amount.ToString() : "";
                receipt.AddRow(t.Date.ToString("d"), credit, debit, balance.ToString());
                balance += t.EffectOnBalance();
            }
            return receipt.GenerateReceipt();
        }

        public BankAccount Account { get => this.account; set => this.account = value; }
    }
}
