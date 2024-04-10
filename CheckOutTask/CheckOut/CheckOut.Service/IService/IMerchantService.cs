using CheckOut.Service.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Service.IService
{
    public interface IMerchantService
    {
        Task<MerchantPaymentTransactions> GetTransactionsById(int Id);
    }
}
