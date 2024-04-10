using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Persistence.Entities
{
    public class BankCardDetails
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public short Cvv { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime VaildFrom { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
