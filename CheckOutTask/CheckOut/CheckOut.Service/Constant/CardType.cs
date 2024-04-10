using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Service.Constant
{
    public static class CardType
    {
        public static string Amex = "3";
        public static string Visa = "4";
        public static string MasterCard = "5";

        public enum CardTypeList
        {
            Amex,
            Visa,
            MasterCard
        }
    }
}
