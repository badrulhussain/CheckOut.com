namespace CKOBankSimulator.Controllers.Model
{
    public class PaymentRequest
    {
        public string Token { get; set; }
        public string MerchantId { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public BankCard CustomerCard { get; set; }
        public BankCard MerchantCard { get; set; }
    }
}
