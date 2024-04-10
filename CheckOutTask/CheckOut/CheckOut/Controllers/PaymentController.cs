using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckOut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        [HttpGet("GetToken")]
        public string GetToken()
        {
            return new Guid().ToString();
        }

        [HttpGet("GetBankCardInfo")]
        public string GetBankCardInfo()
        {
            return "GetCardInfo";
        }

        [HttpGet("GetTransactionById")]
        public ActionResult GetTransactionById(Guid Token)
        {
            return null;
        }

        [HttpGet("GetMerchantTransactionsById")]
        public ActionResult GetMerchantTransactionsById(Guid Token)
        {
            return null;
        }

        [HttpPost]
        public object Post([FromBody] string value)
        {
            return null;
        }

        //// GET: api/<PaymentController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<PaymentController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PaymentController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PaymentController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PaymentController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
