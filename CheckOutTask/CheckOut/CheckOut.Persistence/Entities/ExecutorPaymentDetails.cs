namespace CheckOut.Persistence.Entities
{
    public class ExecutorPaymentDetails
    {
        public string Token { get; set; }
        public string MerchantId { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public ExecutorCardDetails CustomerCard { get; set; }
        public ExecutorCardDetails MerchantCard { get; set; }
    }
}
