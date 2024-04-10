using CheckOut.Persistence.Entities;
using CheckOut.Service.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Service.IService
{
    public interface IWalletService
    {
        Task<BankCard> GetBankCardDetails(string email);
        void AddMerchantBalance(ExecutorPaymentDetails executorPaymentDetails);
    }
}
