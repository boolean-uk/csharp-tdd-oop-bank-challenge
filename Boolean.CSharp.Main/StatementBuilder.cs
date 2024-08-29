using System.Text;


namespace Boolean.CSharp.Main
{
    public class StatementBuilder : IStatement
    {
        private StringBuilder _statementBuilder = new();
        private void BuildColumns() 
        {
            _statementBuilder.Append("date".PadRight(11));
            _statementBuilder.Append("||".PadRight(3));
            _statementBuilder.Append("credit".PadRight(8));
            _statementBuilder.Append("||".PadRight(3));
            _statementBuilder.Append("debit".PadRight(7));
            _statementBuilder.Append("||".PadRight(3));
            _statementBuilder.Append("balance");
            _statementBuilder.AppendLine();
        }
        private void BuildStatements(List<Transaction> transactions) 
        {
            foreach (Transaction item in transactions)
            {
                _statementBuilder.Append(item.Date.PadRight(11));
                if (item.Amount < 0) 
                {
                    _statementBuilder.Append("||".PadRight(11));
                    _statementBuilder.Append("||".PadRight(3));
                    string amount = item.Amount.ToString("0.00").Substring(1);
                    _statementBuilder.Append(amount.PadRight(7));
                    _statementBuilder.Append("||".PadRight(3));
                }
                else
                {
                    _statementBuilder.Append("||".PadRight(3));
                    string amount = item.Amount.ToString("0.00");
                    _statementBuilder.Append(amount.PadRight(amount.Length+1));
                    _statementBuilder.Append("||".PadRight(amount.Length+3));
                    _statementBuilder.Append("||".PadRight(3));
                }
                string balance = item.Balance.ToString("0.00");
                _statementBuilder.Append(balance.PadRight(balance.Length+1));
                _statementBuilder.AppendLine();
            }
        }
        public string GenerateStatement(List<Transaction> transactions)
        {
            BuildColumns();
            BuildStatements(transactions);
            return _statementBuilder.ToString();
        }
    }
}
