using CheckOut.Persistence.Entities;

namespace CheckOut.Persistence.IRepo
{
    public interface IWalletRepo
    {
        Task<BankCardDetails> GetBankCardDetails(string email);
        void AddNewBalance(MerchantWallet merchantWallet);
    }
}
