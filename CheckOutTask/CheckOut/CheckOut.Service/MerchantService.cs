using CheckOut.Persistence.IRepo;
using CheckOut.Service.DataModel;
using CheckOut.Service.IService;

namespace CheckOut.Service
{
    public class MerchantService : IMerchantService
    {
        private readonly ILedgerRepo _ledgerRepo;

        public MerchantService(ILedgerRepo ledgerRepo)
        {
            _ledgerRepo = ledgerRepo;
        }

        public async Task<MerchantPaymentTransactions> GetTransactionsById(int Id)
        {
            var transactions = await _ledgerRepo.GetTransactionsByMerchantId(Id);

            var merchantPaymentTransactions = new MerchantPaymentTransactions()
            {
                MerchantTransactions = new List<MerchantTransaction>()
            };

            foreach (var transaction in transactions)
            {
                merchantPaymentTransactions.MerchantTransactions.Add(new MerchantTransaction
                {
                    Id = transaction.Id,
                    Token = transaction.Token.ToString(),
                    MerchantId = transaction.MerchantId,
                    MerchentType = transaction.MerchentType.ToString(),
                    CustomerEmail = transaction.CustomerEmail,
                    Amount = transaction.Amount.ToString(),
                    Currency = transaction.Currency.ToString(),
                    CreatedOn = transaction.CreatedOn.ToString(),
                    Status = transaction.Status.ToString()
                });
            }

            return merchantPaymentTransactions;
        }
    }
}
