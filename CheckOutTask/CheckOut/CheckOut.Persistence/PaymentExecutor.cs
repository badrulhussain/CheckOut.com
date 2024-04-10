using CheckOut.Persistence.Entities;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CheckOut.Persistence
{
    public class PaymentExecutor : IPaymentExecutor
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;

        public PaymentExecutor(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            setBaseAddress();
        }

        public async Task<string> ExecuteOrder(ExecutorPaymentDetails paymentRequest)
        {
            var paymentRequestJson = JsonSerializer.Serialize(paymentRequest);
            var requestContent = new StringContent(paymentRequestJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_configuration["CKOBankApiProperties:PaymentServiceProviderApiPath"], 
                requestContent);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        private void setBaseAddress()
        {
            _httpClient.BaseAddress = new
                Uri(_configuration["CKOBankApiProperties:BaseUrl"]);
        }
    }
}
