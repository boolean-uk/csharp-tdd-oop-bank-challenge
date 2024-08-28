using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class DebitTransaction : ITransaction
    {
        public decimal operationAmount { get; }
        public decimal beforeAmount { get; }
        public decimal afterAmount { get; }
        public Operation operation { get; set; } = Operation.Add;

        public DebitTransaction(decimal operationAmount, decimal beforeAmount)
        {
            this.operationAmount = operationAmount;
            this.beforeAmount = beforeAmount;
            afterAmount = beforeAmount + operationAmount;
        }

        public decimal GetBalance()
        {
            return afterAmount;
        }

    }
}
