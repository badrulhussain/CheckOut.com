namespace CKOBankSimulator.Controllers.Model
{
    public class Account
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
