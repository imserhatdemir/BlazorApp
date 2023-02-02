using static System.Net.WebRequestMethods;

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
        public List<CustomerNum> AdminCustomerNums { get; set; } = new List<CustomerNum>();

        public event Action OnChange;

        public async Task<CustomerNum> AddNewNumber(CustomerNum slide)
        {
            var result = await _httpClient.PostAsJsonAsync("api/customernum", slide);
            return (await result.Content
                .ReadFromJsonAsync<ServiceResponse<CustomerNum>>()).Data;
        }

        public async Task AddNumber(CustomerNum slider)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customernum/admin", slider);
            AdminCustomerNums = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<CustomerNum>>>()).Data;
            await GetNumber();
            OnChange.Invoke();
        }

        public CustomerNum CreateNumber()
        {
            var newCategory = new CustomerNum { IsNew = true, Editing = true };
            AdminCustomerNums.Add(newCategory);
            OnChange.Invoke();
            return newCategory;
        }

        public async Task DeleteNumber(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/customernum/admin/{id}");
        }

        public async Task GetAdminNumber()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<CustomerNum>>>("api/customernum/admin");
            if (response != null && response.Data != null)
                AdminCustomerNums = response.Data;
        }

        public async Task GetNumber()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<CustomerNum>>>("api/CustomerNum");
            if (response != null && response.Data != null)
                CustomerNums = response.Data;
        }

        public async Task<ServiceResponse<CustomerNum>> GetNumberId(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<CustomerNum>>($"api/customernum/{id}/");
            return result;
        }

        public async Task UpdateNumber(CustomerNum slider)
        {
            var response = await _httpClient.PutAsJsonAsync("api/customernum/admin/", slider);
            AdminCustomerNums = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<CustomerNum>>>()).Data;
            await GetAdminNumber();
        }
    }
}
