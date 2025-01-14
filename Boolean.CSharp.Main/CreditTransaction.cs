using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CreditTransaction : ITransaction
    {
        public decimal operationAmount { get;}
        public decimal beforeAmount { get; }
        public decimal afterAmount { get; }
        public Operation operation { get; set; } = Operation.Subtract;

        public CreditTransaction(decimal operationAmount, decimal beforeAmount)
        {
            this.operationAmount = operationAmount;
            this.beforeAmount = beforeAmount;
            this.afterAmount = beforeAmount - operationAmount ;
        }

        public decimal GetBalance()
        {
            return afterAmount;
        }

       
    }
}
