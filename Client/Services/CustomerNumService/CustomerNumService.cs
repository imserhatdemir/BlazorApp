namespace BlazorApp.Client.Services.CustomerNumService
{
    public class CustomerNumService : ICustomerNumService
    {
        private readonly HttpClient _httpClient;

        public CustomerNumService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<CustomerNum> CustomerNums { get; set; } = new List<CustomerNum>();

        public async Task GetNumber()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<CustomerNum>>>("api/CustomerNum");
            if (response != null && response.Data != null)
                CustomerNums = response.Data;
        }
    }
}
