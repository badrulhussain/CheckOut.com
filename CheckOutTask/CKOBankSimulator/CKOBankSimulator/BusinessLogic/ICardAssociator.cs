using CKOBankSimulator.Controllers.Model;

namespace CKOBankSimulator.BusinessLogic
{
    public interface ICardAssociator
    {
        string ProcessPayment(PaymentRequest paymentRequest);
    }
}
