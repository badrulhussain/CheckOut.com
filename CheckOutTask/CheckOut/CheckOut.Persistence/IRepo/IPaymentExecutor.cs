using CheckOut.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Persistence
{
    public interface IPaymentExecutor
    {
        Task<string> ExecuteOrder(ExecutorPaymentDetails paymentRequest);
    }
}
