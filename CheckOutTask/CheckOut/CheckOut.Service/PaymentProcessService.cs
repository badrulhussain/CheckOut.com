using CheckOut.Persistence;
using CheckOut.Persistence.Entities;
using CheckOut.Persistence.IRepo;
using CheckOut.Service.IService;
using DummyDataBase;

namespace CheckOut.Service
{
    public class PaymentProcessService : IPaymentProcessService
    {
        private readonly ILedgerRepo _lLedgerRepo;
        private readonly IPaymentExecutor _paymentExecutor;
        private readonly IWalletService _walletService;
        private readonly IMockDb _mockDb;

        public PaymentProcessService(ILedgerRepo lLedgerRepo, 
            IPaymentExecutor paymentExecutor, 
            IWalletService walletService,
            IMockDb mockDb)
        {
            _lLedgerRepo = lLedgerRepo;
            _paymentExecutor = paymentExecutor;
            _walletService = walletService;
            _mockDb = mockDb;
        }

        public async Task<string> ProcessPayment(PaymentReques paymentRequest)
        {
            var paymentRequestDetailes = new ExecutorPaymentDetails()
            {
                 Token = paymentRequest.Token,
                 MerchantId = paymentRequest.MerchantId,
                 Currency = paymentRequest.Currency,
                 Amount = paymentRequest.Amount,
            };
            paymentRequestDetailes.CustomerCard = new ExecutorCardDetails()
            {
                CardNumber = paymentRequest.Card.Number,
                Cvv = paymentRequest.Card.Cvv,
                FirstName = paymentRequest.Card.FirstName,
                LastName = paymentRequest.Card.LastName,
                VaildFrom = paymentRequest.Card.VaildFrom,
                ExpiryDate = paymentRequest.Card.ExpiryDate
            };

            var MerchentCardDetail = (from card in _mockDb.GetListOfBankCardDetails()
                                     join merchant in _mockDb.GetMerchants()
                                     on card.Id equals merchant.BankId
                                     where merchant.Id == Convert.ToInt32(paymentRequest.MerchantId)
                                     select new
                                     {
                                         card.CardNumber,
                                         card.Cvv,
                                         card.FirstName,
                                         card.LastName,
                                         card.VaildFrom,
                                         card.ExpiryDate
                                     }).First();
            
            paymentRequestDetailes.MerchantCard = new ExecutorCardDetails()
            {
                CardNumber = MerchentCardDetail.CardNumber,
                Cvv = MerchentCardDetail.Cvv.ToString(),
                FirstName = MerchentCardDetail.FirstName,
                LastName = MerchentCardDetail.LastName,
                VaildFrom = MerchentCardDetail.VaildFrom.ToString("MM/yy"),
                ExpiryDate = MerchentCardDetail.ExpiryDate.ToString("MM/yy")
            };

            var status = await _paymentExecutor.ExecuteOrder(paymentRequestDetailes);

            audit(paymentRequestDetailes, status);

            return status;
        }

        private void audit(ExecutorPaymentDetails executorPaymentDetails, string status)
        {
            var paymentTransaction = new PaymentTransaction
            {
                Id = 0,
                Token = Guid.Parse(executorPaymentDetails.Token),
                MerchantId = Convert.ToInt32(executorPaymentDetails.MerchantId),
                MerchentType = _mockDb.GetMerchants()
                    .Where(x => x.Id == Convert.ToInt32(executorPaymentDetails.MerchantId))
                    .FirstOrDefault().Type,

                CustomerEmail = _mockDb.GetListOfBankCardDetails()
                    .Where(x => x.CardNumber == executorPaymentDetails.CustomerCard.CardNumber)
                    .FirstOrDefault().Email,

                Amount = decimal.Parse(executorPaymentDetails.Amount),
                Currency = executorPaymentDetails.Currency,
                CreatedOn = DateTime.Now,
                Status = status
            };

            _lLedgerRepo.AddNewTransaction(paymentTransaction);

            if (status == "Success")
                _walletService.AddMerchantBalance(executorPaymentDetails);
        }

        public async Task<string> CreateToken()
        {
            var token = Guid.NewGuid();

            return token.ToString();
        }
    }
}
