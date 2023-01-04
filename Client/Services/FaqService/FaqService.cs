using BlazorApp.Client.Shared;
using BlazorApp.Shared;
using static System.Net.WebRequestMethods;

namespace BlazorApp.Client.Services.FaqService
{
    public class FaqService : IFaqService
    {
        private readonly HttpClient _httpClient;

        public FaqService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Faq> Faqs { get; set; } = new List<Faq>();
        public List<Faq> AdminFaq { get; set; } = new List<Faq>();

        public event Action OnChange;

        public async Task AddFaq(Faq faq)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Faq/admin", faq);
            AdminFaq = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Faq>>>()).Data;
            await GetFaq();
            OnChange.Invoke();
        }

        public async Task<Faq> AddNewFaq(Faq faq)
        {
            var result = await _httpClient.PostAsJsonAsync("api/faq", faq);
            return (await result.Content
                .ReadFromJsonAsync<ServiceResponse<Faq>>()).Data;
        }

        public Faq CreateNewFaq()
        {
            var newCategory = new Faq { IsNew = true, Editing = true };
            AdminFaq.Add(newCategory);
            OnChange.Invoke();
            return newCategory;
        }

        public async Task DeleteFaq(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/faq/admin/{id}");
        }

        public async Task GetAdminFaq()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Faq>>>("api/Faq/admin");
            if (response != null && response.Data != null)
                AdminFaq = response.Data;
        }

        public async Task GetFaq()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Faq>>>("api/Faq");
            if (response != null && response.Data != null)
                Faqs = response.Data;
        }

        public async Task<ServiceResponse<Faq>> GetFaqById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Faq>>($"api/Faq/{id}/");
            return result;
        }

        public async Task UpdateFaq(Faq faq)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Faq/admin/", faq);
            AdminFaq = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Faq>>>()).Data;
            await GetAdminFaq();
        }
    }
}
