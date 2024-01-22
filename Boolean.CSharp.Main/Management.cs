using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Management
    {
        private decimal limit = 1000;
        public void SendSMS(string message){
            // Send SMS using Twilio
        }

        public bool OverDraftLimit(decimal amount){
            // Check if the amount is over the limit
            if (amount < limit){
                return true;
            }
            return false;
        }
    }
}