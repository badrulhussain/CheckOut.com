using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Persistence.Entities
{
    public class PaymentExecution
    {
        public string Token { get; set; }
        public string MerchantID { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public BankCardDetails CustomerCard { get; set; }
        public BankCardDetails MerchantCard { get; set; }
    }
}
