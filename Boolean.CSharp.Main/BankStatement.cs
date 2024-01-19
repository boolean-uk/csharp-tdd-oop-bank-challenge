namespace Boolean.CSharp.Main
{
    public class BankStatement
    {
        public List<Transaction> Transactions { get; private set; }

        public BankStatement(List<Transaction> transactions)
        {
            Transactions = transactions;
        }

        public void PrintStatement()
        {
            Console.WriteLine("date       || credit  || debit  || balance");
            foreach(var transaction in Transactions.OrderByDescending(t => t.Date))
            {
                Console.WriteLine($"{transaction.Date:dd/MM/yyyy} || {transaction.Credit:0.00} || {transaction.Debit:0.00} || {transaction.BalanceAfterTransaction:0.00}");
            }
        }
    }
}
