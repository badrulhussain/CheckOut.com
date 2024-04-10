using CheckOut.Persistence.Entities;
using CheckOut.Service.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Service.Extentions
{
    public static class CardHelper
    {
        public static string GetCardType(this string cardNumber)
        {
            var firstDigit = new string(cardNumber.Take(1).ToArray());

            if (firstDigit == CardType.Visa)
            {
                return CardType.CardTypeList.Visa.ToString();
            }
            else if (firstDigit == CardType.MasterCard)
            {
                return CardType.CardTypeList.MasterCard.ToString();
            }
            else if (firstDigit == CardType.Amex)
            {
                return CardType.CardTypeList.Amex.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
