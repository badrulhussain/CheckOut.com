using CKOBankSimulator.Controllers.Model;
using CKOBankSimulator.DummyDb;

namespace CKOBankSimulator.BusinessLogic
{
    public class CardAssociator : ICardAssociator
    {
        private readonly IMockDB _mockDB;
        public CardAssociator(IMockDB mockDB)
        {
            _mockDB = mockDB;
        }
        public string ProcessPayment(PaymentRequest paymentRequest)
        {
            var Customer = _mockDB.GetAccounts()
                .Where(x => x.CardNumber == paymentRequest.CustomerCard.CardNumber)
                .FirstOrDefault();

            if (Customer == null)
            {
                return "50402";
            }

            if (Customer.Cvv != Convert.ToInt32(paymentRequest.CustomerCard.Cvv))
            {
                return "D";
            }

            if (Customer.CardNumber != paymentRequest.CustomerCard.CardNumber)
            {
                return "20014";
            }


            return "10000";
        }
    }
}
