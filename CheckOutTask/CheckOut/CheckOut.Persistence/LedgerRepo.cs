using CheckOut.Persistence.Entities;
using CheckOut.Persistence.IRepo;
using DummyDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Persistence
{
    public class LedgerRepo : ILedgerRepo
    {
        private readonly IMockDb _mockDb;

        public LedgerRepo(IMockDb mockDb)
        {
            _mockDb = mockDb;
        }

        public async Task<List<PaymentTransaction>> GetTransactionsByMerchantId(int Id)
        {
            var transaction = await _mockDb.GetPaymentTransactions();

            transaction = transaction.Where(x => x.MerchantId == Id).ToList();

            return transaction;
        }

        public void AddNewTransaction(PaymentTransaction paymentTransaction)
        {
            _mockDb.AddLedgerPaymentTransaction(paymentTransaction);
        }
    }
}
