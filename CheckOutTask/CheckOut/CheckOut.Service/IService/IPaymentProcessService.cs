using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Service.IService
{
    public interface IPaymentProcessService
    {
        Task<string> CreateToken();
        Task<string> ProcessPayment(PaymentReques paymentRequestRequestDataModel);
    }
}
