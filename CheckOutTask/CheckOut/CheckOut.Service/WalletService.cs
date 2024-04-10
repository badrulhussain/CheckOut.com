using CheckOut.Service.DataModel;
using CheckOut.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckOut.Persistence;
using CheckOut.Persistence.IRepo;
using CheckOut.Persistence.Entities;
using CheckOut.Service.Constant;
using CheckOut.Service.Extentions;

namespace CheckOut.Service
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepo _walletRepo;
        public WalletService(IWalletRepo walletRepo)
        {
            _walletRepo = walletRepo;
        }
        public async Task<BankCard> GetBankCardDetails(string email)
        {
            var bankCardData = await _walletRepo.GetBankCardDetails(email);

            // null check here

            BankCard bankCard = new BankCard
            {
                Number = bankCardData.CardNumber.MaskAllBut(4),
                Cvv = bankCardData.Cvv.ToString(),
                FirstName = bankCardData.FirstName,
                LastName = bankCardData.LastName,
                VaildFrom = bankCardData.VaildFrom.ToString("MM/yy"),
                ExpiryDate = bankCardData.ExpiryDate.ToString("MM/yy"),
                Type = bankCardData.CardNumber.GetCardType()
            };

            return bankCard;
        }

        public void AddMerchantBalance(ExecutorPaymentDetails executorPaymentDetails)
        {
            var merchantWallet = new MerchantWallet
            {
                Token = Guid.Parse(executorPaymentDetails.Token),
                MerchantCardNumber = executorPaymentDetails.CustomerCard.CardNumber,
                CustomerCardNumber = executorPaymentDetails.CustomerCard.CardNumber,
                MerchantBanlence = decimal.Parse(executorPaymentDetails.Amount),
                CustomerBanlence =  - decimal.Parse(executorPaymentDetails.Amount),
                Currency = executorPaymentDetails.Currency
            };

            _walletRepo.AddNewBalance(merchantWallet);
        }
    }
}
