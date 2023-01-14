using System.Net.Http;

namespace BlazorApp.Client.Services.HumanService
{
    public class HumanService : IHumanService
    {
        private readonly HttpClient _httpClient;

        public HumanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<HumanResources> MainHumans { get; set; } = new List<HumanResources>();
        public List<HumanResources> AdminHumans { get; set; } = new List<HumanResources>();

        public event Action OnChange;

        public async Task AddHuman(HumanResources human)
        {
            var response = await _httpClient.PostAsJsonAsync("api/human/admin", human);
            AdminHumans = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<HumanResources>>>()).Data;
            await GetAdminHumans();
            OnChange.Invoke();
        }

        public HumanResources CreateNewHuman()
        {
            var newCategory = new HumanResources { IsNew = true, Editing = true };
            AdminHumans.Add(newCategory);
            OnChange.Invoke();
            return newCategory;
        }

        public async Task GetAdminHumans()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<HumanResources>>>("api/human/admin");
            if (response != null && response.Data != null)
                AdminHumans = response.Data;
        }

        public async Task<ServiceResponse<HumanResources>> GetFaqById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<HumanResources>>($"api/Human/{id}/");
            return result;
        }

        public async Task GetHumans()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<HumanResources>>>("api/human");
            if (response != null && response.Data != null)
                MainHumans = response.Data;
        }

        public async Task UpdateHuman(HumanResources human)
        {
            var response = await _httpClient.PutAsJsonAsync("api/human/admin", human);
            AdminHumans = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<HumanResources>>>()).Data;
            await GetAdminHumans();
            OnChange.Invoke();
        }
    }
}
