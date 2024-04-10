using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Persistence.Entities
{
    public class PaymentTransaction
    {
        public int Id { get; set; }
        public Guid Token { get; set; }
        public int MerchantId { get; set; }
        public int MerchentType { get; set; }
        public string CustomerEmail { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; }

    }
}
