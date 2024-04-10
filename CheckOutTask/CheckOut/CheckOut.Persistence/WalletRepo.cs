using CheckOut.Persistence.Entities;
using CheckOut.Persistence.IRepo;
using DummyDataBase;

namespace CheckOut.Persistence
{
    public class WalletRepo : IWalletRepo
    {
        private readonly IMockDb _mockDb;
        public WalletRepo(IMockDb mockDb)
        {
            _mockDb = mockDb;
        }

        public void AddNewBalance(MerchantWallet merchantWallet)
        {
            _mockDb.AddMerchantWallet(merchantWallet);
        }

        public async Task<BankCardDetails> GetBankCardDetails(string email)
        {
            var CardData = _mockDb.GetListOfBankCardDetails()
                .Where(x => x.Email == email).FirstOrDefault();
                        
            return CardData != null ? CardData : null;
        }
    }
}
