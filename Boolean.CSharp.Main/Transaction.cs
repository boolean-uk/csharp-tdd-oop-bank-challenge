﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private DateTime date;
        private double amount;
        private string type;

        private static readonly string timeFormat = "dd-MM-yyyy";

        public Transaction(double amount, string type, DateTime date)
        {
            this.date = date;
            this.amount = amount;
            this.type = type;
        }

        public string GetDate()
        {
            return date.ToString(timeFormat, CultureInfo.InvariantCulture);
        }

        public double Amount => amount;

        public string Type => type;
        public DateTime DateTimeTrans => date;
    }
}
