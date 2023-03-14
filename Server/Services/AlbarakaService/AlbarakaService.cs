namespace BlazorApp.Server.Services.AlbarakaService
{
    public class AlbarakaService : IAlbarakaService
    {
        private readonly HttpClient _httpClient;

        public AlbarakaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://epostest.albarakaturk.com.tr/ALBMerchantService/MerchantJSONAPI.svc");
        }
        public Task<ServiceResponse<bool>> FulfillOrder(HttpRequest httpRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ProcessPaymentAsync(string storeId, string apiKey, string orderId, decimal amount, string currency, string paymentType)
        {
            var requestData = new Dictionary<string, string>
        {
            { "storekey", apiKey },
            { "storeid", storeId },
            { "orderid", orderId },
            { "amount", amount.ToString() },
            { "currency", currency },
            { "paymentType", paymentType }
        };

            var requestContent = new FormUrlEncodedContent(requestData);

            var response = await _httpClient.PostAsync("/payment", requestContent);

            var responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }
    }
}
