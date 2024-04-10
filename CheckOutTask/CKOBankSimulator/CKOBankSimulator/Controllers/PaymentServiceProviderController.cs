using CKOBankSimulator.BusinessLogic;
using CKOBankSimulator.Controllers.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CKOBankSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentServiceProviderController : ControllerBase
    {
        private readonly ICardAssociator _cardAssociator;

        public PaymentServiceProviderController(ICardAssociator cardAssociator)
        {
            _cardAssociator = cardAssociator;
        }

        [HttpPost]
        public ActionResult Post(PaymentRequest paymentRequest)
        {
            var response = _cardAssociator.ProcessPayment(paymentRequest);

            if (response != "10000")
                BadRequest(response);

            return Ok("10000");
        }
    }
}
