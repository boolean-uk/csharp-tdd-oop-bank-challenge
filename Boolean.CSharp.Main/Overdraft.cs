using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public class Overdraft
    {
        private static int id = 0;

        private int _id;
        private decimal _amount;
        private OverdraftStatus _status;

        public Overdraft(decimal amount)
        {
            _id = ++id;
            _amount = amount;
            _status = OverdraftStatus.Pending;
        }

        public int Id { get => _id; }
        public decimal Amount { get => _amount; }
        public OverdraftStatus Status { get => _status; set => _status = value; }
    }
}
