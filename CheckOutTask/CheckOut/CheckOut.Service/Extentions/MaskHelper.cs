using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Service.Extentions
{
    public static class MaskHelper
    {
        public static string MaskAllBut(this string value, int lastVisibleDigits)
        {
            var fullString = new StringBuilder();

            for (int i = 0; i < value.Length; i++)
            {
                if( i > (value.Length - lastVisibleDigits))
                    fullString.Append(value[i]);
                else
                    fullString.Append("*");   
            }

            return fullString.ToString();
        }
    }
}
