using CheckOut.Service.DataModel;

namespace CheckOut.Service
{
    public class PaymentReques
    {
        public string Token { get; set; }
        public string MerchantId { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public BankCard Card { get; set; }
    }
}
