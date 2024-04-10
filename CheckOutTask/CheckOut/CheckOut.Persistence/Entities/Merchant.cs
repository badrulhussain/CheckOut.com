using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Persistence.Entities
{
    public class Merchant
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public string CompanyName { get; set; }
        public int Type { get; set; }
    }
}
