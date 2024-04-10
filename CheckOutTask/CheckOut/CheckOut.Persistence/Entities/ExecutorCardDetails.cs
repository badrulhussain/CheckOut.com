using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Persistence.Entities
{
    public class ExecutorCardDetails
    {
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VaildFrom { get; set; }
        public string ExpiryDate { get; set; }
    }
}
