using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Boolean.CSharp.Main.Classes
{
    public class Statement
    {

        public Transaction transaction {  get; set; }

        public IAccount account { get; set; }

        public DateOnly CurrentDate { get; set; }

        public string PrintFormatted(List<Transaction> transactionList)
        {
            if (transactionList == null || transactionList.Count == 0)
            {
                return "No transactions to display.";
            }

            string nameofholder = transactionList[0].Account.AccountHolderName;
            string result = $"Bank statement for: {nameofholder}\n";
            result += "date       || credit     || debit     ||balance\n";

            foreach (var item in transactionList)
            {
                string dateFormatted = item.transactionDate.ToString("dd/MM/yyyy");
                string creditFormatted = item.type == "Deposit" ? item.amount.ToString("F2", CultureInfo.InvariantCulture) : string.Empty;
                string debitFormatted = item.type == "Withdraw" ? Math.Abs(item.amount).ToString("F2", CultureInfo.InvariantCulture) : string.Empty;
                string balanceFormatted = item.Account.balance(nameofholder).ToString("F2", CultureInfo.InvariantCulture);

                result += $"{dateFormatted} || {creditFormatted,-10} || {debitFormatted,-10} || {balanceFormatted,-10}\n";
            }

            return result;
        }

        public async Task sendReceiptAsSms(List<Transaction> transactionList)
        {
            string accountId = "";
            string authToken = "";

            TwilioClient.Init(accountId, authToken);
            var message = await MessageResource.CreateAsync(
                body: PrintFormatted(transactionList),
                from: new Twilio.Types.PhoneNumber(""),
                to: new Twilio.Types.PhoneNumber("")
            );


        }



    }
}
