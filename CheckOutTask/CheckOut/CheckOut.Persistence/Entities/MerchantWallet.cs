using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Persistence.Entities
{
    public class MerchantWallet
    {
        public Guid Token { get; set; }
        public string MerchantCardNumber { get; set; }
        public string CustomerCardNumber { get; set; }
        public decimal MerchantBanlence { get; set; }
        public decimal CustomerBanlence { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
