namespace CheckOut.Persistence.Entities
{
    public class PaymentRequestDetailes
    {
        public string Token { get; set; }
        public string MerchantId { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public BankCardDetails CustomerCard { get; set; }
        public BankCardDetails MerchentCard { get; set; }
    }
}
