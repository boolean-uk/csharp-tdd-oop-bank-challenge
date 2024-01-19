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
            float balance = 0;
            foreach(var transaction in Transactions.OrderByDescending(t => t.Date))
            {
                balance += transaction.Credit;
                balance -= transaction.Debit;
                Console.WriteLine($"{transaction.Date:dd/MM/yyyy} || {transaction.Credit:0.00} || {transaction.Debit:0.00} || {balance:0.00}");
            }
        }
    }
}
