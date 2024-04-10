using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Service.DataModel
{
    public class MerchantTransaction
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public int MerchantId { get; set; }
        public string MerchentType { get; set; }
        public string CustomerEmail { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string CreatedOn { get; set; }
        public string Status { get; set; }
    }
}
