using BlazorApp.Shared;
using static System.Net.WebRequestMethods;

namespace BlazorApp.Client.Services.KvkkService
{
    public class KvkkService : IKvkkService
    {
        private readonly HttpClient _httpClient;

        public KvkkService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Kvkk> KvkkMain { get; set; } = new List<Kvkk>();
        public List<Kvkk> AdminKvkk { get; set; } = new List<Kvkk>();

        public event Action OnChange;

        public async Task AddKvkk(Kvkk brand)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Kvkk/admin", brand);
            AdminKvkk = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Kvkk>>>()).Data;
            await GetKvkk();
            OnChange.Invoke();
        }

        public Kvkk CreateKvkk()
        {
            var newCategory = new Kvkk { IsNew = true, Editing = true };
            AdminKvkk.Add(newCategory);
            OnChange.Invoke();
            return newCategory;
        }

        public async Task GetAdminKvkk()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Kvkk>>>("api/Kvkk/admin");
            if (response != null && response.Data != null)
                AdminKvkk = response.Data;
        }

        public async Task GetKvkk()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Kvkk>>>("api/Kvkk");
            if (response != null && response.Data != null)
                KvkkMain = response.Data;
        }

        public async Task UpdateKvkk(Kvkk brand)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Kvkk/admin", brand);
            AdminKvkk = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Kvkk>>>()).Data;
            await GetKvkk();
            OnChange.Invoke();
        }
    }
}
