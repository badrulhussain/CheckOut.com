using CheckOut.Service;
using CheckOut.Service.DataModel;
using CheckOut.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CheckOut.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IPaymentProcessService _paymentProcessService;
        private readonly IMerchantService _merchantService;
        private readonly IWalletService _walletService;

        public PaymentController(IPaymentProcessService paymentProcessService,
            IWalletService walletService,
            IMerchantService merchantService)
        {
            _paymentProcessService = paymentProcessService;
            _walletService = walletService;
            _merchantService = merchantService;
        }

        [HttpGet("GetToken")]
        public async Task<ActionResult<string>> GetToken()
        {
            var token = await _paymentProcessService.CreateToken();

            if (token == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(token);
        }

        [HttpGet("GetBankCardInfo")]
        public async Task<ActionResult<BankCard>> GetBankCardInfo(string email)
        {
            var response = await _walletService.GetBankCardDetails(email);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpGet("GetMerchantTransactionsById")]
        public async Task<ActionResult<MerchantPaymentTransactions>> GetMerchantTransactionsById(int Id)
        {
            var response = await _merchantService.GetTransactionsById(Id);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(PaymentReques Request)
        {
            var response = await _paymentProcessService.ProcessPayment(Request);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }
    }
}
