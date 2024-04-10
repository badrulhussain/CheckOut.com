using CheckOut.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Persistence.IRepo
{
    public interface ILedgerRepo
    {
        Task<List<PaymentTransaction>> GetTransactionsByMerchantId(int Id);
        void AddNewTransaction(PaymentTransaction executorPaymentDetails);
    }
}
