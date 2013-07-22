using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingSystem
{
    public sealed class CardHelper
    {
        private int cardId;
        private int bankId;
        private string cardNumber;

        public int CardId
        {
            get { return cardId; }
            set { cardId = value; }
        }

        public int BankId
        {
            get { return bankId; }
            set { bankId = value; }
        }

        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }
    }
}