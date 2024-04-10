using CheckOut.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDataBase
{
    public interface IMockDb
    {
        List<BankCardDetails> GetListOfBankCardDetails();
        Task<List<PaymentTransaction>> GetPaymentTransactions();
        List<Merchant> GetMerchants();
        void AddLedgerPaymentTransaction(PaymentTransaction paymentTransaction);
        void AddMerchantWallet(MerchantWallet merchantWallet);
    }
}
